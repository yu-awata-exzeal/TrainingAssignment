
namespace Manager
{
    public class InteractionContext
    {
        public PlayerInventory Inventory { get; init; }
        public InteractType InteractType { get; set; }
    }

    /// <summary>
    /// プレイヤーとインタラクト対象を結びつける
    /// </summary>
    public class InteractionManager
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
}
