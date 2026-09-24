using PageController;
using UnityEngine;

/// <summary>
/// シーン駆動を行うクラス
/// </summary>
public class GameScene : MonoBehaviour
{
    /// <summary>
    /// UICanvas
    /// </summary>
    [SerializeField]
    private Transform _canvasTransform = null;

    private void Start()
    {
        OpenTitlePage();
    }

    private void Update()
    {

    }

    /// <summary>
    /// タイトルを表示
    /// </summary>
    private void OpenTitlePage()
    {

        var titlePageController = new TitlePageController();

        titlePageController.CreatePage();
    }
}
