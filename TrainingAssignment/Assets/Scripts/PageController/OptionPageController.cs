using Manager;
using Page;

namespace PageController
{
    public class OptionPageController : PageControllerBase<OptionPage, OptionContext>
    {
        public override string Name => "OptionPage";

        public override void Setup()
        {
            _context = new OptionContext()
            {
                OptionData = OptionManager.Instance.OptionData,
                OnUpdateSeVolume = OptionManager.Instance.SetSeVolume,
                OnUpdateSeMute = OptionManager.Instance.SetSeMute,
                OnUpdateMouseSensitivity = OptionManager.Instance.SetMouseSensitivity,
                OnRevertOption = OnRevertButtonClick,
                OnResetOption = OnResetButtonClick,
                OnSaveOption = OnSaveButtonClick,
                OnClose = ScreenNavigator.Instance.RemoveTopPage,
            };
        }

        private void OnRevertButtonClick()
        {
            OptionManager.Instance.RevertOption();
            DestroyPage();
        }

        private void OnResetButtonClick()
        {
            OptionManager.Instance.ResetOption();
            DestroyPage();
        }

        private void OnSaveButtonClick()
        {
            OptionManager.Instance.SaveOption();
            DestroyPage();
        }
    }
}
