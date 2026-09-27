using Manager;
using Page;

namespace PageController
{
    public class StageSelectPageController : PageControllerBase<StageSelectPage, StageSelectContext>
    {
        public override string Name => "StageSelectPage";

        public override void Setup()
        {
            _context = new StageSelectContext()
            {
                OnSelectEasyStageClick = OnSelectEasyStage,
                OnSelectHardStageClick = OnSelectHardStage,
                OnSelectStanderdStageClick = OnSelectStanderdStage,
            };
        }

        private void OnSelectEasyStage()
        {
            OnOpenStageSelect(GameScene.StageDataList.Find(x => x.Type == GameStageType.Easy).StageSetting);
        }

        private void OnSelectStanderdStage()
        {
            OnOpenStageSelect(GameScene.StageDataList.Find(x => x.Type == GameStageType.Standerd).StageSetting);
        }

        private void OnSelectHardStage()
        {
            OnOpenStageSelect(GameScene.StageDataList.Find(x => x.Type == GameStageType.Hard).StageSetting);
        }

        private void OnOpenStageSelect(StageSettings setting)
        {
            var controller = new InGamePageController(
                new InGamePageContext()
                {
                    InGameContext = InGameSystem.Context,
                    StageSetting = setting,
                });

            ScreenNavigator.Instance.ChangePage(controller);
        }
    }
}
