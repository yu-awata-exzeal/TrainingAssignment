using Manager;
using System;
using TMPro;
using UnityEngine;

namespace Page
{
    public class InGamePageContext : IContext
    {
        public StageSettings TargetStageSettings { get; set; }
        public Action OnOpenResult { get; init; }
        public Action BackToTitleButtonClick { get; init; }
    }


    public class InGamePage : PageBase<InGamePageContext>
    {
        [SerializeField]
        private TextMeshProUGUI _itemCountText;

        private InGameSystem _inGameManager = new();

        private void Update()
        {

        }

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