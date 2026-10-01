using Manager;
using UnityEngine;

public class Fuel : MonoBehaviour, IInteractable
{
    public static int Content => InGameSystem.Instance.CurrentStageSetting.FuelEnergyAmount;

    /// <summary>
    /// インタラクト処理
    /// </summary>
    /// <param name="context"></param>
    public void Interact(InteractionContext context)
    {
        if (context.InteractType == InteractType.TriggerEnter)
        {
            if (context.Inventory == null)
                return;

            context.Inventory.CollectFuel();
            FuelManager.Instance.RegisterInactiveFuel(this);
        }
    }
}