using Cysharp.Threading.Tasks;
using PageController;
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

        private PageControllerBase _currentPageController = null;
        private bool _isNextAnimation = false;


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
        public async UniTask ChangePage(PageControllerBase controller)
        {
            await PlayBeforeAnimation();
            _currentPageController?.DestroyPage();
            _currentPageController = controller;
            _currentPageController.CreatePage();
            await PlayAfterAnimation();
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
    }
}
