using Manager;
using Page;
using UnityEngine.InputSystem;

namespace PageController
{
    public class InGamePageController : PageControllerBase<InGamePage, InGamePageContext>
    {
        public override string Name => "InGamePage";

        public InGamePageController(InGamePageContext context)
        {
            _context = context;
            _context.OnOpenOption = OpenOption;
        }

        public override void Setup()
        {
            InGameSystem.Instance.Setup(_context.StageSetting);
        }

        public void OpenOption()
        {
            if (ScreenNavigator.Instance.CheckTopPageController<OptionPageController>())
                return;

            if (InputSystem.actions.FindAction("Option").WasPressedThisFrame())
            {
                ScreenNavigator.Instance.ChangePage(new OptionPageController(), false);
            }
        }
    }
}