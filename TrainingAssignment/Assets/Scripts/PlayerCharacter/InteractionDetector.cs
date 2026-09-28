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

        _currentTarget = interactable;
        Interact(InteractType.OnTriggerEnter);
    }

    private void OnTriggerStay(Collider other)
    {
        var interactable = other.GetComponent<IInteractable>();

        if (interactable == null)
        {
            return;
        }

        _currentTarget = interactable;
        Interact(InteractType.OnTriggerStay);
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
            Interact(InteractType.Raycast);
        }
    }

    /// <summary>
    /// 現在検出している対象にインタラクトする。
    /// </summary>
    public void Interact(InteractType type)
    {
        if (_currentTarget == null)
        {
            return;
        }

        InteractionManager.Interact(_inventory, _currentTarget, type);
    }
}
