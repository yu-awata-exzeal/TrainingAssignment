using UnityEngine;

public class Fuel : MonoBehaviour, IInteractable
public class Fuel
{
    public int Content { get; }

    InteractType IInteractable.Type => InteractType.ButtonInput;
    public int Content => _currentStageSetting.FuelContent;

    public void Interact(InteractionContext context)
    {
        context.Inventory.ChatchFuel();
    public Fuel(int conntent)
    {
        Content = conntent;
    }
}