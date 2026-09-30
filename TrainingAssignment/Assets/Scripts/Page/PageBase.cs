using UnityEngine;
using UnityEngine.EventSystems;

namespace Page
{
    /// <summary>
    /// シーン基底クラス
    /// </summary>
    public abstract class PageBase<TContext> : MonoBehaviour where TContext : IContext
    {
        [SerializeField]
        private GameObject _firstSelectable;
        /// <summary>
        /// コンテキスト
        /// </summary>
        public TContext Context { get; protected set; }

        protected virtual void OnSetup() { }
        /// <summary>
        /// シーンセットアップ
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
