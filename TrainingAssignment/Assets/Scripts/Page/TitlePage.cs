using System;

namespace Page
{
    public class TitleContext : IContext
    {
        public Action OnOpenStageSelectClick { get; init; }
    }

    public class TitlePage : PageBase<TitleContext>
    {
        /// <summary>
        /// ステージセレクトに遷移(ボタンUIイベント用)
        /// </summary>
        public void OpenStageSelect()
        {
            Context.OnOpenStageSelectClick.Invoke();
        }
    }
}
