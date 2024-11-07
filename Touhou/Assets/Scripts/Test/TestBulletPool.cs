using UnityEngine;

public class TestBulletPool : MonoPooledObject
{
    public void Update()
    {
        transform.Translate(Vector3.up * Time.deltaTime * 5);

        if (transform.position.y > 6) RetrieveObject();
    }
}
