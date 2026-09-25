using Manager;
using Page;

namespace PageController
{
    public class InGamePageController : PageControllerBase<InGamePage, InGamePageContext>
    {
        public override string Name => "InGamePage";
        private InGameSystem _inGameManager = new();

        public override void Setup()
        {
            _inGameManager.Setup();

            _context = new InGamePageContext()
            {
                BackToTitleButtonClick = BackToTitle,
                OnOpenResult = OpenResult,
            };
        }

        private void BackToTitle()
        {
            ScreenNavigator.Instance.ChangePage(new TitlePageController());
        }

        private void OpenResult()
        {
            ScreenNavigator.Instance.ChangePage(new ResultPageController());
        }
    }
}