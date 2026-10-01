using Manager;
using PageController;
using System;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ゲームシーンを管理するクラス
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
    private Camera _mainCamera = null;

    /// <summary>
    /// ステージ情報リスト
    /// </summary>
    public static List<StageSettingData> StageDataList { get; private set; }
    /// <summary>
    /// メインとなるカメラ
    /// </summary>
    public static Camera MainCamera { get; private set; }

    private void Awake()
    {
        MainCamera = _mainCamera;
        StageDataList = _stageSettingList;
    }

    private void Start()
    {
        OpenTitlePage();
    }

    /// <summary>
    /// タイトルを表示
    /// </summary>
    private void OpenTitlePage()
    {
        ScreenNavigator.Instance.ChangePage(new TitlePageController());
    }
}
