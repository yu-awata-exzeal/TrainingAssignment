/// <summary>
/// プレイヤーとインタラクト対象を結びつける
/// </summary>
public class InteractionService
{
    public static void Interact(PlayerInventory inventory, IInteractable target)
    {
        if (target == null)
        {
            return;
        }

        var context = new InteractionContext()
        {
            Inventory = inventory,
        };

        target.Interact(context);
    }
}
