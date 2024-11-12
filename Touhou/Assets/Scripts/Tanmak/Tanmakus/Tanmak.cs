using System;
using UnityEngine;

public abstract class Tanmak : MonoPooledObject
{
    protected Sprite _sprite;

    protected Single _speed;
    protected Single _damage;

    public Vector2 startDir;

    public override void SpawnObject() => SpawnTanmak();
    public abstract void SpawnTanmak();
}
