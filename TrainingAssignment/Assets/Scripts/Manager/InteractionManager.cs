
namespace Manager
{
    public class InteractionContext
    {
        /// <summary>
        /// プレイヤーのインベントリ
        /// </summary>
        public PlayerInventory Inventory { get; init; }
        /// <summary>
        /// インタラクト方法
        /// </summary>
        public InteractType InteractType { get; set; }
    }

    /// <summary>
    /// プレイヤーとインタラクト対象を結びつける
    /// </summary>
    public class InteractionManager
    {
        /// <summary>
        /// 対象とプレイヤーのインタラクト処理実行
        /// </summary>
        /// <param name="inventory"></param>
        /// <param name="target"></param>
        /// <param name="type"></param>
        public static void Interact(PlayerInventory inventory, IInteractable target, InteractType type)
        {
            if (target == null)
            {
                return;
            }

            var context = new InteractionContext()
            {
                Inventory = inventory,
                InteractType = type
            };

            target.Interact(context);
        }
    }
}
