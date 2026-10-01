using Cysharp.Threading.Tasks;
using PageController;
using UnityEngine;

namespace Manager
{
    public enum GameStageType
    {
        Easy,
        Standard,
        Hard,
    }

    public class InGameContext
    {
        public float MainEnergy { get; private set; }
        public float AuxiliaryEnergy { get; private set; }
        public int FuelCount { get; private set; }

        public void SetMainEnergy(float value)
        {
            MainEnergy = Mathf.Clamp(
                value,
                0,
                InGameSystem.Instance.CurrentStageSetting.MaxBasePointEnergy);
        }

        public void SetAuxiliaryEnergy(float value)
        {
            AuxiliaryEnergy = Mathf.Clamp(
                value,
                0,
                InGameSystem.Instance.CurrentStageSetting.MaxPlayerEnergy);
        }

        public void AddMainEnergy(float value)
        {
            MainEnergy = Mathf.Clamp(
                MainEnergy + value,
                0,
                InGameSystem.Instance.CurrentStageSetting.MaxBasePointEnergy);
        }

        public void AddAuxiliaryEnergy(float value)
        {
            AuxiliaryEnergy = Mathf.Clamp(
                    AuxiliaryEnergy + value,
                    0,
                    InGameSystem.Instance.CurrentStageSetting.MaxPlayerEnergy);
        }

        public void SetFuelCount(int fuelCount)
        {
            FuelCount = fuelCount;
        }
    }

    public class InGameSystem
    {
        private static InGameSystem _instance;
        private static InGameContext _context;
        /// <summary>
        /// 指定されたステージの設定
        /// </summary>
        private StageSettings _currentStageSetting;

        private readonly Vector3 _playerStartPosition = new Vector3(0.0f, 4.0f, 0.0f);
        /// <summary>
        /// インゲーム内経過時間を計測するタイマー
        /// </summary>
        private float _inGameTimer = 0.0f;
        /// <summary>
        /// インゲーム終了フラグ
        /// </summary>
        private bool _isInGameEnded = false;

        public static InGameSystem Instance => _instance ??= new();
        /// <summary>
        /// インゲームのコンテキスト
        /// </summary>
        public static InGameContext Context => _context ??= new();

        public InGameObjectManager ObjectManager { get; private set; }

        /// <summary>
        /// 現在のステージ設定
        /// </summary>
        public StageSettings CurrentStageSetting => _currentStageSetting;
        /// <summary>
        /// 生存時間
        /// </summary>
        public float SurvivalTimer => _inGameTimer;

        /// <summary>
        /// インゲームセットアップ
        /// </summary>
        public void Setup(StageSettings setting)
        {
            _currentStageSetting = setting;
            ResetInGameState();

            ObjectManager = new();
            ObjectManager.CreateObject<PlayerCharacter>(_playerStartPosition, Quaternion.identity);
            ObjectManager.CreateObject<BasePoint>(Vector3.zero, Quaternion.identity);

            CountTimer().Forget();

            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }

        /// <summary>
        /// リセット処理
        /// </summary>
        public void ResetInGameState()
        {
            Context.SetMainEnergy(_currentStageSetting.MaxBasePointEnergy);
            Context.SetAuxiliaryEnergy(_currentStageSetting.MaxPlayerEnergy);
            Context.SetFuelCount(0);
            _inGameTimer = _currentStageSetting.SurvivalTimeLimit;
            _isInGameEnded = false;
            EnemyManager.Instance.ActivateEnemies(_currentStageSetting.IsActivateEnemy);
        }

        /// <summary>
        /// インゲーム内の各タイマー計測
        /// </summary>
        /// <returns></returns>
        private async UniTask CountTimer()
        {
            while (!_isInGameEnded)
            {
                _inGameTimer -= Time.deltaTime;

                if (_inGameTimer < 0.0f)
                {
                    OpenResultPage(ResultType.Clear);
                    _isInGameEnded = true;
                    break;
                }

                ConsumeEnergy();

                if (Context.MainEnergy <= 0.0f)
                {
                    OpenResultPage(ResultType.GameOver);
                    _isInGameEnded = true;
                    break;
                }

                await UniTask.Yield();
            }
        }

        private void ConsumeEnergy()
        {
            Context.AddMainEnergy(-CurrentStageSetting.EnergyConsumptionRate * Time.deltaTime);
            Context.AddAuxiliaryEnergy(-(CurrentStageSetting.EnergyConsumptionRate / 2.0f) * Time.deltaTime);
        }

        /// <summary>
        /// クリア判定時の処理
        /// </summary>
        private void OpenResultPage(ResultType result)
        {
            ResetInGameState();
            ObjectManager.DestroyAllObjects();
            ScreenNavigator.Instance.ChangePage(new ResultPageController() { Type = result });

            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
    }
}
