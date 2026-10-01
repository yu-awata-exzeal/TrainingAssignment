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
    /// ページを管理するコントローラーの基底クラス
    /// </summary>
    public abstract class PageControllerBase<TPage, TContext>
        : PageControllerBase
        where TPage : PageBase<TContext>
        where TContext : IContext
    {
        /// <summary>
        /// 管理しているページ
        /// </summary>
        private TPage _page;
        protected TContext _context;

        /// <summary>
        /// ページ名
        /// </summary>
        public abstract string Name { get; }

        /// <summary>
        /// プレハブパス
        /// </summary>
        public string PrefabPath => $"Prefabs/Page/{Name}";

        public abstract void Setup();

        /// <summary>
        /// ページ生成処理
        /// </summary>
        public sealed override void CreatePage()
        {
            Setup();
            _page = ResourceManager.InstantiatePrefab<TPage>(Vector3.zero, Quaternion.identity, PrefabPath);
            _page.transform.SetParent(ScreenNavigator.Instance.CanvasScope, false);
            _page.Setup(_context);
        }

        /// <summary>
        /// ページ削除処理
        /// </summary>
        public sealed override void DestroyPage()
        {
            ResourceManager.RemovePrefabCache(PrefabPath);
            Object.Destroy(_page.gameObject);
        }
    }
}
