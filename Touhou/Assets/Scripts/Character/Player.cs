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

    /* All Public or Public getter only */
    public Single defaultPlayerSpeed = 1.0f;

    private void Awake()
    {
        _rigid = GetComponent<Rigidbody2D>();
        _playerTanmakManager = new PlayerTanmakManager(_pooler, transform, new TanmakLevelInfo[][]
        {
            new TanmakLevelInfo[] {
                new TanmakLevelInfo("ReimuDefaultTanmak", 1, 0.1f
                , new Vector2[]{new Vector2(0, 0.8f)}
                , new Vector2[]{Vector2.up })
            },
            new TanmakLevelInfo[] {
                new TanmakLevelInfo("ReimuDefaultTanmak", 2, 0.1f
                , new Vector2[]{new Vector2(-0.2f, 0.8f), new Vector2(0.2f, 0.8f)}
                , new Vector2[]{Vector2.up, Vector2.up })
            },
            new TanmakLevelInfo[] {
                new TanmakLevelInfo("ReimuDefaultTanmak", 3, 0.1f
                , new Vector2[]{new Vector2(-0.4f, 0.8f), new Vector2(0, 0.8f), new Vector2(0.4f, 0.8f)}
                , new Vector2[]{Vector2.up, Vector2.up, Vector2.up })
                , new TanmakLevelInfo("ReimuFollowTanmak", 2, 0.4f
                , new Vector2[]{new Vector2(-0.5f, 0), new Vector2(0.5f, 0)}
                , new Vector2[]{Vector2Util.RotateVector(Vector2.up, 45),
                    Vector2Util.RotateVector(Vector2.up, -45) })
            }
        });
        
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
