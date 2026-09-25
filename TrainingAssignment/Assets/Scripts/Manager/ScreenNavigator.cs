using PageController;
using UnityEngine;

namespace Manager
{
    public class ScreenNavigator : MonoBehaviour, IScreenNaigator
    {
        [SerializeField]
        private Transform _worldScope;

        [SerializeField]
        private Transform _canvasScope;

        private PageControllerBase _currentPageController = null;

        public static IScreenNaigator Instance { get; private set; }

        public Transform WorldScope => _worldScope;

        public Transform CanvasScope => _canvasScope;

        private void Awake()
        {
            Instance = this;
        }

        public void ChangePage(PageControllerBase controller)
        {
            _currentPageController?.DestroyPage();
            _currentPageController = controller;
            _currentPageController.CreatePage();
        }
    }
}
