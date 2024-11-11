using System;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct UserSetPoolerObject
{
    public MonoPooledObject monoPooledObject;
    public Int32 poolCount;
}

public class MonoObjectPooler : MonoBehaviour
{
    [SerializeField] private UserSetPoolerObject[] _userSetPools;
    private Queue<MonoPooledObject>[] _pools;
    private Dictionary<String, Int32> _poolKeyFinder = new Dictionary<String, Int32>();

    private void InputPoolsToQueue(Int32 index)
    {
        var pool = _userSetPools[index];
        for (Int32 i = 0; i < pool.poolCount; i++)
        {
            MonoPooledObject obj = Instantiate(pool.monoPooledObject);
            obj.transform.SetParent(transform.GetChild(index));
            obj.gameObject.SetActive(false);
            obj.DestroyEvent += OnDestroyPooledObject;
            obj.poolingKey = index;
            _pools[index].Enqueue(obj);
        }
    }
    private void Start()
    {
        _pools = new Queue<MonoPooledObject>[_userSetPools.Length];
        for (Int32 i = 0; i < _userSetPools.Length; i++) 
        {
            var pool = _userSetPools[i];
            _poolKeyFinder.Add(pool.monoPooledObject.name, i);
            _pools[i] = new Queue<MonoPooledObject>(pool.poolCount);
            new GameObject(_userSetPools[i].monoPooledObject.name).transform.SetParent(transform);
            InputPoolsToQueue(i);
        }
    }

    private void OnDestroyPooledObject(MonoPooledObject pObj, Int32 key)
    {
        _pools[key].Enqueue(pObj);
        pObj.gameObject.SetActive(false);
    }

    public MonoPooledObject SpawnPoolObject(Int32 i)
    {
        if (_pools[i].Count == 0)
        {
            InputPoolsToQueue(i);
            _userSetPools[i].poolCount *= 2;
        }

        try
        {
            MonoPooledObject obj = _pools[i].Dequeue();
            obj.gameObject.SetActive(true);
            return obj;
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }

    public MonoPooledObject SpawnPoolObject(String key)
    {
        return SpawnPoolObject(_poolKeyFinder[key]);
    }
}
