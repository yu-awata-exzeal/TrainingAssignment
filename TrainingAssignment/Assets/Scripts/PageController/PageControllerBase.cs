using Manager;
using Page;

namespace PageController
{
    /// <summary>
    /// 
    /// </summary>
    public abstract class PageControllerBase<TPage, TContext>
        where TPage : PageBase<TContext>
        where TContext : IContext
    {
        /// <summary>
        /// 管理しているページオブジェクト
        /// </summary>
        private TPage _page;
        protected TContext _context;

        public abstract string Name { get; }

        public string PrefabPath => $"Prefabs/Page/{Name}";

        public PageControllerBase()
        {
            Setup();
        }

        public abstract void Setup();

        public void CreatePage()
        {
            _page = ResourceManager.InstantiatePrefab<TPage>(PrefabPath);

            _page.Setup(_context);
        }
    }
}
