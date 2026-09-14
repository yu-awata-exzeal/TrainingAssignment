using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerCharacter : MonoBehaviour
{
    [SerializeField]
    private float _speed = 5.0f;
    private InputAction _moveAction;

    private void Start()
    {
        // "Move" と "Jump" のリファレンスを探す
        _moveAction = InputSystem.actions.FindAction("Move");
    }

    private void Update()
    {

    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        // 移動処理
        var moveValue = _moveAction.ReadValue<Vector2>();
        var move = new Vector2(moveValue.x, moveValue.y) * _speed * Time.deltaTime;
        transform.Translate(move);
    }
}