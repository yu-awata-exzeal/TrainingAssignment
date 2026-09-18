using UnityEngine;

/// <summary>
/// インタラクト対象を検出・保持する
/// </summary>
public class InteractionDetector : MonoBehaviour
{
    [SerializeField]
    private PlayerInventory _inventory;

    private IInteractable _currentTarget;

    private void OnTriggerEnter2D(Collider2D other)
    {
        var interactable = other.GetComponent<IInteractable>();

        if (interactable == null)
        {
            return;
        }

        _currentTarget = interactable;

        if (_currentTarget.Type == InteractType.OnTrigger)
        {
            Interact();
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        var interactable = other.GetComponent<IInteractable>();

        if (interactable == _currentTarget)
        {
            _currentTarget = null;
        }
    }

    /// <summary>
    /// 現在検出している対象にインタラクトする。
    /// </summary>
    public void Interact()
    {
        if (_currentTarget == null)
        {
            return;
        }

        InteractionService.Interact(_inventory, _currentTarget);
    }
}
