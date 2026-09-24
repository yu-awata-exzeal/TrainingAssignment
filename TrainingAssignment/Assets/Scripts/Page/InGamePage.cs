using Manager;
using System;

namespace Page
{
    public class InGameContext : IContext
    {
        public Action OnOpenResult { get; init; }
        public Action BackToTitleButtonClick { get; init; }
    }


    public class InGamePage : PageBase<InGameContext>
    {
        private InGameManager _inGameManager = new();

        private void OnDestroy()
        {

        }

        /// <summary>
        /// タイトル画面に遷移(ボタンUIイベント用)
        /// </summary>
        public void OpenResult()
        {
            Context.OnOpenResult.Invoke();
        }

        /// <summary>
        /// タイトル画面に遷移(ボタンUIイベント用)
        /// </summary>
        public void BackToTitle()
        {
            Context.BackToTitleButtonClick.Invoke();
        }
    }

}