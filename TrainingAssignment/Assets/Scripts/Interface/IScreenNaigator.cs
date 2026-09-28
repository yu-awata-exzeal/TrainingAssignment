
using PageController;
using UnityEngine;

public interface IScreenNaigator
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
    public void ChangePage(PageControllerBase controller);
}
