using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    /* Programmer Setting Stats */
    [SerializeField] private Single playerSpeed = 0;

    /* Private Field */
    private Rigidbody2D _rigid;
    private PlayerActions _playerInput;

    /* All Public or Public getter only */
    public Single defaultPlayerSpeed = 1.0f;

    private void Awake()
    {
        _rigid = GetComponent<Rigidbody2D>();

        _playerInput = new PlayerActions();
        _playerInput.Enable();

        defaultPlayerSpeed = playerSpeed;
    }
    public void Update()
    {

    }

    public void FixedUpdate()
    {
        PlayerConcentration(_playerInput.PlayerControl.Concentration);
        PlayerMove(_playerInput.PlayerControl.Move);
    }

    private void PlayerConcentration(InputAction context)
    {
        Boolean isPressed = context.IsPressed();
        if (isPressed) playerSpeed = defaultPlayerSpeed / 2;
        else playerSpeed = defaultPlayerSpeed;
    }
    private void PlayerMove(InputAction context)
    {
        Vector2 input = context.ReadValue<Vector2>();
        _rigid.MovePosition((Vector2)transform.position + input * Time.deltaTime * playerSpeed);
    }
}
