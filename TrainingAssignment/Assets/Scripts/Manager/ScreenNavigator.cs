using Cysharp.Threading.Tasks;
using PageController;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Manager
{
    public class ScreenNavigator : MonoBehaviour, IScreenNaigator
    {
        public static IScreenNaigator Instance { get; private set; }

        [SerializeField]
        private Animator _fadeAnimator;
        [SerializeField]
        private Transform _worldScope;

        [SerializeField]
        private Transform _canvasScope;

        private List<PageControllerBase> _currentPageController = new();

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
        public async UniTask ChangePage(PageControllerBase controller, bool isDestroyBeforePage = true)
        {
            if (isDestroyBeforePage)
            {
                await PlayBeforeAnimation();

                foreach (var pageController in _currentPageController)
                {
                    pageController?.DestroyPage();
                }
                _currentPageController.Clear();
            }

            _currentPageController.Add(controller);
            controller.CreatePage();

            if (isDestroyBeforePage)
            {
                await PlayAfterAnimation();
            }
        }

        public void RemoveTopPage()
        {
            var topPageController = _currentPageController.LastOrDefault();
            topPageController?.DestroyPage();
            _currentPageController.Remove(topPageController);
        }

        public async UniTask PlayBeforeAnimation()
        {
            _fadeAnimator.gameObject.SetActive(true);
            _fadeAnimator.Play("FadeIn");
            await UniTask.WaitUntil(() => _fadeAnimator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1.0f);
        }

        public async UniTask PlayAfterAnimation()
        {
            _fadeAnimator.Play("FadeOut");

            await UniTask.WaitUntil(() => _fadeAnimator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1.0f);

            _fadeAnimator.gameObject.SetActive(false);
        }

        public bool CheckTopPageController<TPageController>() where TPageController : PageControllerBase
        {
            return _currentPageController.LastOrDefault() as TPageController != null;
        }
    }
}
