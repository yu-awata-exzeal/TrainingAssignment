using Manager;
using UnityEngine;

public class BasePoint : MonoBehaviour, IInteractable
{
    private int AuxiliaryContain = 10;
    InteractType IInteractable.Type => InteractType.ButtonInput;

    /// <summary>
    /// インタラクト処理
    /// </summary>
    /// <param name="context"></param>
    public void Interact(InteractionContext context)
    {
        if (context.InteractType == InteractType.ButtonInput)
        {
            if (!context.Inventory.TryUseFuel(out var contain))
            {
                return;
            }
            //回復
            InGameSystem.Context.AddMainEnergy(contain);
        }
        else if (context.InteractType == InteractType.OnTrigger)
        {
            InGameSystem.Context.AddAuxiliaryEnergy(AuxiliaryContain);
        }
    }
}
