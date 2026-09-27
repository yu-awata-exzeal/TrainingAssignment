using Manager;
using UnityEngine;

public class BasePoint : MonoBehaviour, IInteractable
{
    InteractType IInteractable.Type => InteractType.ButtonInput;

    public void Interact(InteractionContext context)
    {
        if (!context.Inventory.TryUseFuel(out var contain))
        {
            return;
        }

        Debug.Log($"[{nameof(BasePoint)}] インタラクト");

        //回復
        InGameSystem.Context.AddMainEnergy(contain);
    }
}
