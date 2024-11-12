using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[System.Serializable]
public struct UserSetPoolerObject
{
    public MonoPooledObject monoPooledObject;
    public Int32 poolCount;

    public UserSetPoolerObject(MonoPooledObject pObj, Int32 poolCount)
    {
        monoPooledObject = pObj;
        this.poolCount = poolCount;
    }
}

public class MonoObjectPooler : MonoBehaviour
{
    //#todo: 생성자 개선, 오브젝트 추가할 수 있는 함수 제작하기
    public MonoObjectPooler(String pName)
    {
        GameObject obj = new GameObject(pName);
        obj.AddComponent<MonoObjectPooler>();
    }
    public MonoObjectPooler(String pName, Transform pParent)
    {
        GameObject obj = new GameObject(pName);
        obj.transform.parent = pParent;
        obj.AddComponent<MonoObjectPooler>();
    }

    [SerializeField] private UserSetPoolerObject[] _userSetPools;
    private List<Queue<MonoPooledObject>> _pools;
    private Dictionary<String, Int32> _poolKeyFinder;

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
    private void InputPoolsToQueue(MonoPooledObject pObj, Int32 size, Int32 index)
    {
        UserSetPoolerObject pool = new UserSetPoolerObject(pObj, size);
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
    private void Awake()
    {
        _poolKeyFinder = new Dictionary<String, Int32>();
        _pools = new List<Queue<MonoPooledObject>>(new Queue<MonoPooledObject>[_userSetPools.Length]);
        for (Int32 i = 0; i < _userSetPools.Length; i++) 
        {
            var pool = _userSetPools[i];
            _poolKeyFinder.Add(pool.monoPooledObject.name, i);
            _pools[i] = new Queue<MonoPooledObject>();
            new GameObject(_userSetPools[i].monoPooledObject.name).transform.SetParent(transform);
            InputPoolsToQueue(i);
        }
    }

    public void AddMonoObject(MonoPooledObject obj, Int32 size)
    {
        Int32 index = _pools.Count;
        _poolKeyFinder.Add(obj.name, index);
        _pools.Add(new Queue<MonoPooledObject>());
        new GameObject(obj.name).transform.SetParent(transform);
        Debug.Log(obj.name);
        InputPoolsToQueue(obj, size, index);
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
            obj.SpawnObject();
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
