using Manager;
using Page;

namespace PageController
{
    public class InGamePageController : PageControllerBase<InGamePage, InGameContext>
    {
        public override string Name => "InGamePage";
        private InGameManager _inGameManager = new();

        public override void Setup()
        {
            _inGameManager.Setup();

            _context = new InGameContext()
            {
                BackToTitleButtonClick = BackToTitle,
            };
        }

        private void OnDestroy()
        {

        }

        private void BackToTitle()
        {
            var controller = new TitlePageController();

            controller.CreatePage();
        }

        private void OpenResult()
        {
            var controller = new ResultPageController();

            controller.CreatePage();
        }
    }
}