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
                OnOpenInGameButtonClick = OnOpenStageSelect,
            };
        }

        private void OnOpenStageSelect()
        {
            ScreenNavigator.Instance.ChangePage(new InGamePageController());
        }
    }
}
