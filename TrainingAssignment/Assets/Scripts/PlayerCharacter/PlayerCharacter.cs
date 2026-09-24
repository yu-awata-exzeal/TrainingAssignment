using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerCharacter : InteractionDetector
{
    /// <summary>
    /// 移動速度
    /// </summary>
    [SerializeField]
    private float _speed = 5.0f;
    /// <summary>
    /// 攻撃距離
    /// </summary>
    [SerializeField]
    private float _attackRange = 30.0f;

    private InputAction _moveAction;
    private InputAction _rotationAction;

    private void Start()
    {
        // "Move"のリファレンスを探す
        _moveAction = InputSystem.actions.FindAction("Move");
        _rotationAction = InputSystem.actions.FindAction("Look");
    }

    private void Update()
    {

    }

    private void FixedUpdate()
    {
        Move();
        Attack();
        InteractButtonInput();
    }

    /// <summary>
    /// 移動処理
    /// </summary>
    private void Move()
    {
        // 移動処理
        var moveValue = _moveAction.ReadValue<Vector2>();
        var move = new Vector2(moveValue.x, moveValue.y) * _speed * Time.deltaTime;
        transform.Translate(move);

        var rotationValue = _rotationAction.ReadValue<Vector2>();

        transform.Rotate(0.0f, 0.0f, rotationValue.x * Time.deltaTime);
    }

    /// <summary>
    /// 攻撃処理
    /// </summary>
    private void Attack()
    {
        if (InputSystem.actions.FindAction("Attack").WasPressedThisFrame())
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.up, _attackRange);

            if (hit.collider == null)
            {
                Debug.Log($"Hit: {hit.collider.name}");
            }
        }
        Debug.DrawRay(transform.position, transform.up, Color.blue, _attackRange);
    }

    /// <summary>
    /// ボタン入力によるインタラクト処理
    /// </summary>
    private void InteractButtonInput()
    {
        if (InputSystem.actions.FindAction("Interact").WasPressedThisFrame())
        {
            InteractButtonInput();
        }
    }
}