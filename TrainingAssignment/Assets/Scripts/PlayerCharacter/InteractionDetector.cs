using Manager;
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

        if (interactable.Type == InteractType.ButtonInput
            || interactable.Type == InteractType.OnTrigger)
        {
            _currentTarget = interactable;
        }


        if (_currentTarget?.Type == InteractType.OnTrigger)
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

    protected void CheckRaycastInteractable(Vector3 start, Vector3 direction, float range)
    {
        RaycastHit2D hit = Physics2D.Raycast(start, direction, range);

        if (hit.collider is IInteractable target)
        {
            _currentTarget = target;
            Interact();
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

        InteractionManager.Interact(_inventory, _currentTarget);
    }
}
