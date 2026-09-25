using Manager;
using Page;
using UnityEngine;

namespace PageController
{
    public abstract class PageControllerBase
    {
        /// <summary>
        /// ページ生成処理
        /// </summary>
        public abstract void CreatePage();
        /// <summary>
        /// ページ削除処理
        /// </summary>
        public abstract void DestroyPage();
    }

    /// <summary>
    /// 
    /// </summary>
    public abstract class PageControllerBase<TPage, TContext>
        : PageControllerBase
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

        /// <summary>
        /// ページ生成処理
        /// </summary>
        public sealed override void CreatePage()
        {
            _page = ResourceManager.InstantiatePrefab<TPage>(PrefabPath);
            _page.transform.SetParent(ScreenNavigator.Instance.CanvasScope, false);
            _page.Setup(_context);
        }

        /// <summary>
        /// ページ削除処理
        /// </summary>
        public sealed override void DestroyPage()
        {
            ResourceManager.UnloadPrefab(PrefabPath);
            Object.Destroy(_page.gameObject);
        }
    }
}
