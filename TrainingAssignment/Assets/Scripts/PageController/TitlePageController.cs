using Manager;
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

        private void OnOpenStageSelect()
        {
            ScreenNavigator.Instance.ChangePage(new StageSelectPageController());
        }
    }
}
