using UnityEngine;
using UnityEngine.EventSystems;

namespace Page
{
    /// <summary>
    /// ページ基底クラス
    /// </summary>
    public abstract class PageBase<TContext> : MonoBehaviour where TContext : IContext
    {
        [SerializeField]
        private GameObject _firstSelectable;

        /// <summary>
        /// コンテキスト
        /// </summary>
        public TContext Context { get; protected set; }

        /// <summary>
        /// ページ固有のセットアップ
        /// </summary>
        protected virtual void OnSetup() { }

        /// <summary>
        /// ページセットアップ
        /// </summary>
        public void Setup(TContext context)
        {
            Context = context;
            OnSetup();

            if (_firstSelectable == null)
                return;

            EventSystem.current.SetSelectedGameObject(_firstSelectable);
        }

    }
}
