using Cysharp.Threading.Tasks;
using PageController;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Manager
{
    public class ScreenNavigator : MonoBehaviour, IScreenNavigator
    {
        public static IScreenNavigator Instance { get; private set; }

        [SerializeField]
        private Animator _fadeAnimator;
        [SerializeField]
        private Transform _worldScope;

        [SerializeField]
        private Transform _canvasScope;

        private List<PageControllerBase> _currentPageControllerList = new();

        public Transform WorldScope => _worldScope;

        public Transform CanvasScope => _canvasScope;

        private void Awake()
        {
            Instance = this;
            _fadeAnimator.gameObject.SetActive(false);
        }

        /// <summary>
        /// ページ遷移処理
        /// </summary>
        /// <param name="controller"></param>
        public async UniTask ChangePage(PageControllerBase controller, bool destroyPreviousPage = true)
        {
            if (destroyPreviousPage)
            {
                await PlayBeforeAnimation();

                foreach (var pageController in _currentPageControllerList)
                {
                    pageController?.DestroyPage();
                }
                _currentPageControllerList.Clear();
            }

            _currentPageControllerList.Add(controller);
            controller.CreatePage();

            if (destroyPreviousPage)
            {
                await PlayAfterAnimation();
            }
        }

        public void RemoveTopPage()
        {
            var topPageController = _currentPageControllerList.LastOrDefault();
            topPageController?.DestroyPage();
            _currentPageControllerList.Remove(topPageController);
        }

        private async UniTask PlayBeforeAnimation()
        {
            _fadeAnimator.gameObject.SetActive(true);
            _fadeAnimator.Play("FadeIn");
            await UniTask.WaitUntil(() => _fadeAnimator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1.0f);
        }

        private async UniTask PlayAfterAnimation()
        {
            _fadeAnimator.Play("FadeOut");

            await UniTask.WaitUntil(() => _fadeAnimator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1.0f);

            _fadeAnimator.gameObject.SetActive(false);
        }

        public bool CheckTopPageController<TPageController>() where TPageController : PageControllerBase
        {
            return _currentPageControllerList.LastOrDefault() as TPageController != null;
        }
    }
}
