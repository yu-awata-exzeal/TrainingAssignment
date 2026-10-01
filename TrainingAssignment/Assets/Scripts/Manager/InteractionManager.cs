
namespace Manager
{
    public class InteractionContext
    {
        /// <summary>
        /// インタラクトを実行したオブジェクト
        /// </summary>
        public InteractionDetector Interactor { get; init; }
        /// <summary>
        /// プレイヤーのインベントリ
        /// </summary>
        public PlayerInventory Inventory { get; init; }
        /// <summary>
        /// インタラクト方法
        /// </summary>
        public InteractType InteractType { get; init; }
    }

    /// <summary>
    /// プレイヤーとインタラクト対象を結びつける
    /// </summary>
    public class InteractionManager
    {
        /// <summary>
        /// 対象とプレイヤーのインタラクト処理実行
        /// </summary>
        /// <param name="inventory">プレイヤーのインベントリ</param>
        /// <param name="target">インタラクト対象</param>
        /// <param name="Interactor">インタラクトを実行したオブジェクト</param>
        /// <param name="type">インタラクト方法</param>
        public static void Interact(
            PlayerInventory inventory, IInteractable target, InteractionDetector Interactor, InteractType type)
        {
            if (target == null)
            {
                return;
            }

            var context = new InteractionContext()
            {
                Interactor = Interactor,
                Inventory = inventory,
                InteractType = type
            };

            target.Interact(context);
        }
    }
}
