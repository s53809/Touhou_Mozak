using UnityEngine;

public class ReimuDefaultTanmak : Tanmak
{
    public void Update()
    {
        transform.Translate(startDir * Time.deltaTime * _speed);
        if (transform.position.y > 6) RetrieveObject();
    }

    public override void SpawnTanmak()
    {
        _speed = 5;
        _damage = 3;
    }
    
}
