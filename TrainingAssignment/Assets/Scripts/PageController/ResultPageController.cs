using Page;

namespace PageController
{
    public class ResultPageController : PageControllerBase<ResultPage, ResultContext>
    {

        public override string Name => "ResultPage";
        public override void Setup()
        {

            _context = new ResultContext()
            {
                OnOpenTitleButtlonClick = OpenTitle,
                OnRestartInGameButtonClick = RestartInGame,
            };
        }

        private void OnDestroy()
        {

        }

        private void OpenTitle()
        {

        }

        private void RestartInGame()
        {

        }
    }

}
