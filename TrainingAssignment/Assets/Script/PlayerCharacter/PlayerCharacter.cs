using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerCharacter : MonoBehaviour
{
    /// <summary>
    /// インタラクト対象を検出・保持している
    /// </summary>
    [SerializeField]
    private InteractionDetector _interactionDetector;
    [SerializeField]
    private PlayerInventory _inventory;
    [SerializeField]
    private float _speed = 5.0f;


    private InputAction _moveAction;

    private void Start()
    {
        // "Move"のリファレンスを探す
        _moveAction = InputSystem.actions.FindAction("Move");
    }

    private void Update()
    {

    }

    private void FixedUpdate()
    {
        Move();

        Interact();
    }

    private void Move()
    {
        // 移動処理
        var moveValue = _moveAction.ReadValue<Vector2>();
        var move = new Vector2(moveValue.x, moveValue.y) * _speed * Time.deltaTime;
        transform.Translate(move);
    }

    private void Interact()
    {
        if (InputSystem.actions.FindAction("Interact").WasPressedThisFrame())
        {
            InteractionService.Interact(_inventory, _interactionDetector.CurrentTarget);
        }
    }
}