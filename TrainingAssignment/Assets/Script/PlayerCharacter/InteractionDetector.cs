using UnityEngine;

/// <summary>
/// インタラクト対象を検出・保持する
/// </summary>
public class InteractionDetector : MonoBehaviour
{
    private IInteractable _currentTarget;

    public IInteractable CurrentTarget => _currentTarget;

    private void OnTriggerEnter2D(Collider2D other)
    {
        var interactable = other.GetComponent<IInteractable>();

        if (interactable != null)
        {
            _currentTarget = interactable;
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
}
