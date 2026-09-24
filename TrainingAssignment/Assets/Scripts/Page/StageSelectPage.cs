using System;

namespace Page
{
    public class StageSelectContext : IContext
    {
        public Action OnOpenInGameButtonClick { get; init; }
    }

    public class StageSelectPage : PageBase<StageSelectContext>
    {

        private void OnDestroy()
        {

        }

        /// <summary>
        /// インゲーム画面に遷移(ボタンUIイベント用)
        /// </summary>
        public void OpenInGame()
        {
            Context.OnOpenInGameButtonClick.Invoke();
        }
    }
}
