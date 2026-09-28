using UnityEngine;

namespace Page
{
    /// <summary>
    /// シーン基底クラス
    /// </summary>
    public abstract class PageBase<TContext> : MonoBehaviour where TContext : IContext
    {
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
        }

    }
}
