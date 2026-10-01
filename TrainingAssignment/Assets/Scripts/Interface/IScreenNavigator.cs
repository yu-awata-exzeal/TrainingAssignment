
using Cysharp.Threading.Tasks;
using PageController;
using UnityEngine;

public interface IScreenNavigator
{
    /// <summary>
    /// オブジェクトをぶら下げる親
    /// </summary>
    public Transform WorldScope { get; }
    /// <summary>
    /// UIをぶら下げる親
    /// </summary>
    public Transform CanvasScope { get; }
    /// <summary>
    /// ページ遷移処理
    /// </summary>
    /// <param name="controller"></param>
    public UniTask ChangePage(PageControllerBase controller, bool isDestroyBeforePage = true);

    public void RemoveTopPage();

    public bool CheckTopPageController<TPageController>() where TPageController : PageControllerBase;
}
