
using PageController;
using System;
using UnityEngine;

namespace Page
{
    public class ResultContext : IContext
    {
        /// <summary>
        /// リザルト
        /// </summary>
        public ResultType ResultType { get; init; }
        /// <summary>
        /// タイトルへ遷移するボタンを押された際の処理
        /// </summary>
        public Action OnOpenTitleButtlonClick { get; init; }
        /// <summary>
        /// 再挑戦ボタンを押された際の処理
        /// </summary>
        public Action OnRestartInGameButtonClick { get; init; }
    }

    public class ResultPage : PageBase<ResultContext>
    {
        [SerializeField]
        private GameObject ClearBG;
        [SerializeField]
        private GameObject GameOverBG;

        protected override void OnSetup()
        {
            ClearBG.SetActive(Context.ResultType == ResultType.Clear);
            GameOverBG.SetActive(Context.ResultType == ResultType.GameOver);
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
