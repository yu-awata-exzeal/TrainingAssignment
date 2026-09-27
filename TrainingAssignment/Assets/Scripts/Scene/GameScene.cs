using Manager;
using PageController;
using System;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// シーン駆動を行うクラス
/// </summary>
public class GameScene : MonoBehaviour
{
    [Serializable]
    public class StageSettingData
    {
        public GameStageType Type;
        public StageSettings StageSetting;
    }

    [SerializeField]
    private List<StageSettingData> _stageSettingList;

    [SerializeField]
    private Transform _worldTransform = null;
    /// <summary>
    /// UICanvas
    /// </summary>
    [SerializeField]
    private Transform _canvasTransform = null;
    [SerializeField]
    private Camera _mainCamera = null;

    public static List<StageSettingData> StageDataList { get; private set; }
    public static Camera WorldCamera { get; private set; }

    private void Awake()
    {
        WorldCamera = _mainCamera;
        StageDataList = _stageSettingList;
    }

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
        ScreenNavigator.Instance.ChangePage(new TitlePageController());
    }
}
