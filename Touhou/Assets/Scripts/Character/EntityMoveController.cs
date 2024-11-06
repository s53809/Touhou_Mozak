using System;
using UnityEngine;

public class EntityMoveController : MonoBehaviour
{
    public Single defaultPlayerSpeed = 1.0f;

    [SerializeField] private Single playerSpeed = 0;
    private void Update()
    {
        Single h = Input.GetAxisRaw("Horizontal");
        Single v = Input.GetAxisRaw("Vertical");

        Boolean toggleShift = Input.GetKey(KeyCode.LeftShift);
        if (toggleShift) playerSpeed = defaultPlayerSpeed / 2;
        else playerSpeed = defaultPlayerSpeed;

        transform.Translate(new Vector3(
            h * playerSpeed * Time.deltaTime,
            v * playerSpeed * Time.deltaTime, 
            0));
    }
}
