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
                OnSelectStandardStageClick = OnSelectStandardStage,
            };
        }

        private void OnSelectEasyStage()
        {
            OpenInGame(GameScene.StageDataList.Find(x => x.Type == GameStageType.Easy).StageSetting);
        }

        private void OnSelectStandardStage()
        {
            OpenInGame(GameScene.StageDataList.Find(x => x.Type == GameStageType.Standard).StageSetting);
        }

        private void OnSelectHardStage()
        {
            OpenInGame(GameScene.StageDataList.Find(x => x.Type == GameStageType.Hard).StageSetting);
        }

        private void OpenInGame(StageSettings setting)
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
