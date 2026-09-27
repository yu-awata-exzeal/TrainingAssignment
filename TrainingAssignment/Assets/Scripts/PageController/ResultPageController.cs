using Manager;
using Page;

namespace PageController
{
    public enum ResultType
    {
        Clear,
        GameOver,
    }

    public class ResultPageController : PageControllerBase<ResultPage, ResultContext>
    {

        public override string Name => "ResultPage";

        public ResultType Type { get; init; }

        public override void Setup()
        {

            _context = new ResultContext()
            {
                OnOpenTitleButtlonClick = OpenTitle,
                OnRestartInGameButtonClick = RestartInGame,
            };
        }

        private void OpenTitle()
        {
            ScreenNavigator.Instance.ChangePage(new TitlePageController());
        }

        private void RestartInGame()
        {
            ScreenNavigator.Instance.ChangePage(new InGamePageController(new()
            {
                InGameContext = InGameSystem.Context,
                StageSetting = InGameSystem.Instance.CurrentStageSetting,
            }));
        }
    }

}
