using System;
using UnityEngine;

public class MonoPooledObject : MonoBehaviour
{
    public delegate void OnDestroyDelegate(MonoPooledObject obj, Int32 key);
    public event OnDestroyDelegate DestroyEvent;
    public Int32 poolingKey;

    public virtual void SpawnObject() { }
    public virtual void RetrieveObject() { DestroyEvent?.Invoke(this, poolingKey); }
}
