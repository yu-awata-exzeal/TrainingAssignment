using Manager;
using Page;

namespace PageController
{
    public class InGamePageController : PageControllerBase<InGamePage, InGamePageContext>
    {
        public override string Name => "InGamePage";

        public InGamePageController(InGamePageContext context)
        {
            _context = context;
        }

        public override void Setup()
        {
            InGameSystem.Instance.Setup(_context.StageSetting);
        }
    }
}