using System;
using UnityEngine;
using UnityEngine.InputSystem;
using MinseoUtil;

public class Player : MonoBehaviour
{
    /* Programmer Setting Stats */
    [SerializeField] private Single _playerSpeed = 0;
    [SerializeField] private MonoObjectPooler _pooler;

    /* Private Field */
    private Rigidbody2D _rigid;
    private PlayerActions _playerInput;
    private PlayerTanmakManager _playerTanmakManager;
    private ITanmakLoader _tanmakInfo;

    /* All Public or Public getter only */
    public Single defaultPlayerSpeed = 1.0f;

    private void Awake()
    {
        _tanmakInfo = new ReimuTanmakLoader(NLuaEnv.Ins);

        _rigid = GetComponent<Rigidbody2D>();
        _playerTanmakManager = new PlayerTanmakManager(_pooler, transform, _tanmakInfo.GetTanmakLevel());
        
        _playerInput = new PlayerActions();
        _playerInput.Enable();

        defaultPlayerSpeed = _playerSpeed;
    }
    public void Update()
    {
        PlayerShoot(_playerInput.PlayerControl.Shoot);
        if (Input.GetKeyDown(KeyCode.T)) { _playerTanmakManager.LevelUp(); }
    }

    public void FixedUpdate()
    {
        PlayerConcentration(_playerInput.PlayerControl.Concentration);
        PlayerMove(_playerInput.PlayerControl.Move);
    }

    private void PlayerConcentration(InputAction context)
    {
        Boolean isPressed = context.IsPressed();
        if (isPressed) _playerSpeed = defaultPlayerSpeed / 2;
        else _playerSpeed = defaultPlayerSpeed;
    }
    private void PlayerMove(InputAction context)
    {
        Vector2 input = context.ReadValue<Vector2>();
        _rigid.MovePosition((Vector2)transform.position + input * Time.deltaTime * _playerSpeed);
    }

    private void PlayerShoot(InputAction context)
    {
        Boolean isPressed = context.IsPressed();
        if (isPressed) _playerTanmakManager.OnShoot();
    }
}
