using UnityEngine;

public class ReimuFollowTanmak : Tanmak
{
    public void Update()
    {
        transform.Translate(startDir * Time.deltaTime * _speed);
        if (transform.position.y > 6) RetrieveObject();
    }

    public override void SpawnTanmak()
    {
        _speed = 4;
        _damage = 3;
    }


}
