using Manager;
using UnityEngine;

public class BasePoint : MonoBehaviour, IInteractable
{
    private float _auxiliaryRecoveryRate = 5;

    /// <summary>
    /// インタラクト処理
    /// </summary>
    /// <param name="context"></param>
    public void Interact(InteractionContext context)
    {
        if (context.InteractType == InteractType.ButtonInput)
        {
            if (!context.Inventory.TryUseFuel(out var recoveryAmount))
            {
                return;
            }
            // メイン電力を回復
            InGameSystem.Context.AddMainEnergy(recoveryAmount);
        }
        else if (context.InteractType == InteractType.TriggerStay)
        {
            // プレイヤー電力を回復
            InGameSystem.Context.AddAuxiliaryEnergy(_auxiliaryRecoveryRate * Time.deltaTime);
        }
    }
}
