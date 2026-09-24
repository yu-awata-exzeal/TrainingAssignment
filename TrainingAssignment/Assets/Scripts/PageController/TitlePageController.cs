using Page;

namespace PageController
{
    public class TitlePageController : PageControllerBase<TitlePage, TitleContext>
    {
        public override string Name => "TitlePage";

        public override void Setup()
        {
            _context = new TitleContext()
            {
                OnOpenStageSelectButtonClick = OnOpenStageSelect,
            };
        }

        private void OnDestroy()
        {

        }

        private void OnOpenStageSelect()
        {
            var controller = new StageSelectPageController();

            controller.CreatePage();
        }
    }
}
