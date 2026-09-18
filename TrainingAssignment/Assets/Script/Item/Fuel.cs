using UnityEngine;

public class Fuel : MonoBehaviour, IInteractable
{
    [SerializeField]
    private StageSettings _currentStageSetting;

    InteractType IInteractable.Type => InteractType.OnTrigger;
    public int Content => _currentStageSetting.FuelContent;

    public void Interact(InteractionContext context)
    {
        context.Inventory.ChatchFuel();
    }
}