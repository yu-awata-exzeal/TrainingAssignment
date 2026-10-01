using System;

namespace Page
{
    public class StageSelectContext : IContext
    {
        public Action OnSelectEasyStageClick { get; init; }
        public Action OnSelectStandardStageClick { get; init; }
        public Action OnSelectHardStageClick { get; init; }
    }

    public class StageSelectPage : PageBase<StageSelectContext>
    {
        /// <summary>
        /// Easyステージのインゲーム画面に遷移(ボタンUIイベント用)
        /// </summary>
        public void OpenEasyStage()
        {
            Context.OnSelectEasyStageClick.Invoke();
        }

        /// <summary>
        /// Standerdステージのインゲーム画面に遷移(ボタンUIイベント用)
        /// </summary>
        public void OpenStandardStage()
        {
            Context.OnSelectStandardStageClick.Invoke();
        }

        /// <summary>
        /// Hardステージのインゲーム画面に遷移(ボタンUIイベント用)
        /// </summary>
        public void OpenHardStage()
        {
            Context.OnSelectHardStageClick.Invoke();
        }
    }
}
