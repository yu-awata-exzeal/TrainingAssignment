using Manager;
using UnityEngine;

public class Fuel : MonoBehaviour, IInteractable
{
    public static int Content => InGameSystem.Instance.CurrentStageSetting.FuelContent;

    /// <summary>
    /// インタラクト処理
    /// </summary>
    /// <param name="context"></param>
    public void Interact(InteractionContext context)
    {
        if (context.InteractType == InteractType.OnTriggerEnter)
        {
            if (context.Inventory == null)
                return;

            context.Inventory?.ChatchFuel();
            FuelManager.Instance.RegisterUnActiveFuel(this);
        }
    }
}