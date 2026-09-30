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
                optionData = OptionManager.Instance.OptionData,
                OnUpdateSeVolume = OptionManager.Instance.SetSeVolume,
                OnUpdateSeMute = OptionManager.Instance.SetSeMute,
                OnUpdateMouseSensitivity = OptionManager.Instance.SetMouseSensitivity,
                OnRevertOption = OnRevertButtonClick,
                OnResetOption = OnResetButtonClick,
                OnSaveOption = OnSaveButtonClick,
                OnDestroy = ScreenNavigator.Instance.RemoveTopPage,
            };
        }

        private void OnRevertButtonClick()
        {
            OptionManager.Instance.ReverOption();
            DestroyPage();
        }

        private void OnResetButtonClick()
        {
            OptionManager.Instance.ResetOption();
            DestroyPage();
        }
        private void OnSaveButtonClick()
        {
            OptionManager.Instance.Save();
            DestroyPage();
        }
    }
}
