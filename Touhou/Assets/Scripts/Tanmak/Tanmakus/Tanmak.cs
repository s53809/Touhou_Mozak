using UnityEngine;

public abstract class Tanmak : MonoPooledObject
{
    public override void SpawnObject() => SpawnTanmak();
    public abstract void SpawnTanmak();
}
