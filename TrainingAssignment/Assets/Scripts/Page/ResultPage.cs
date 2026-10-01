
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
        public Action OnOpenTitleClick { get; init; }
        /// <summary>
        /// 再挑戦ボタンを押された際の処理
        /// </summary>
        public Action OnRestartInGameClick { get; init; }
    }

    public class ResultPage : PageBase<ResultContext>
    {
        [SerializeField]
        private GameObject _clearBG;
        [SerializeField]
        private GameObject _gameOverBG;

        protected override void OnSetup()
        {
            _clearBG.SetActive(Context.ResultType == ResultType.Clear);
            _gameOverBG.SetActive(Context.ResultType == ResultType.GameOver);
        }

        /// <summary>
        /// タイトル画面に遷移(ボタンUIイベント用)
        /// </summary>
        public void OpenTitle()
        {
            Context.OnOpenTitleClick.Invoke();
        }

        /// <summary>
        /// 再挑戦(ボタンUIイベント用)
        /// </summary>
        public void RestartInGame()
        {
            Context.OnRestartInGameClick.Invoke();
        }
    }
}
