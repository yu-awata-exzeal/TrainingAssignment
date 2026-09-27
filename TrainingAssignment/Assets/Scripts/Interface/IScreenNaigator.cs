
using PageController;
using UnityEngine;

public interface IScreenNaigator
{
    public Transform WorldScope { get; }

    public Transform CanvasScope { get; }

    public void ChangePage(PageControllerBase controller);
}
