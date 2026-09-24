
using System;

namespace Page
{
    public class ResultContext : IContext
    {
        public Action OnOpenTitleButtlonClick { get; init; }

        public Action OnRestartInGameButtonClick { get; init; }
    }

    public class ResultPage : PageBase<ResultContext>
    {


        private void OnDestroy()
        {

        }

        /// <summary>
        /// タイトル画面に遷移(ボタンUIイベント用)
        /// </summary>
        public void OpenTitle()
        {
            Context.OnOpenTitleButtlonClick.Invoke();
        }

        /// <summary>
        /// 再挑戦(ボタンUIイベント用)
        /// </summary>
        public void RestartInGame()
        {
            Context.OnRestartInGameButtonClick.Invoke();
        }
    }
}
