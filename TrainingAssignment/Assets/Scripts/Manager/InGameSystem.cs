using Cysharp.Threading.Tasks;
using PageController;
using UnityEngine;

namespace Manager
{
    public enum GameStageType
    {
        Easy,
        Standerd,
        Hard,
    }

    public class InGameContext
    {
        public float MainEnergy { get; private set; }
        public float AuxiliaryEnergy { get; private set; }
        public int FuelCount { get; private set; }

        public void SetMainEnergy(float setValue)
        {
            MainEnergy = setValue;
        }

        public void SetAuxiliaryEnergy(float setValue)
        {
            AuxiliaryEnergy = setValue;
        }

        public void AddMainEnergy(float addValue)
        {
            MainEnergy += addValue;
        }

        public void AddAuxiliaryEnergy(float addValue)
        {
            AuxiliaryEnergy += addValue;
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
        private InGameObjectManager _objectManager;

        /// <summary>
        /// インゲーム内経過時間を計測するタイマー
        /// </summary>
        private float _inGameTimer = 0.0f;
        /// <summary>
        /// インゲーム終了フラグ
        /// </summary>
        private bool _isEndInGame = false;

        public static InGameSystem Instance => _instance ??= new();
        public static InGameContext Context => _context ??= new();
        public StageSettings CurrentStageSetting => _currentStageSetting;
        public float SurvivaleTimer => _inGameTimer;

        /// <summary>
        /// インゲームセットアップ
        /// </summary>
        public void Setup(StageSettings setting)
        {
            _currentStageSetting = setting;
            Reset();
            _objectManager = new();
            _objectManager.CreateObject<PlayerCharacter>();
            _objectManager.CreateObject<BasePoint>();

            CountTimer().Forget();

            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }

        public void Reset()
        {
            Context.SetMainEnergy(_currentStageSetting.MaxBasePointEnergy);
            Context.SetAuxiliaryEnergy(_currentStageSetting.MaxPlayerEnergy);
            Context.SetFuelCount(0);
            _inGameTimer = _currentStageSetting.SurvivalTimeLimit;
            _isEndInGame = false;
            EnemyManager.Instance.ActivateEnemys(_currentStageSetting.IsActivateEnemy);
        }

        /// <summary>
        /// インゲーム内の各タイマー計測
        /// </summary>
        /// <returns></returns>
        private async UniTask CountTimer()
        {
            _inGameTimer = _currentStageSetting.SurvivalTimeLimit;

            while (!_isEndInGame)
            {
                _inGameTimer -= Time.deltaTime;

                if (_inGameTimer < 0.0f)
                {
                    OpenResult(ResultType.Clear);
                    _isEndInGame = true;
                    break;
                }

                ConsumeEnergy();

                if (Context.MainEnergy <= 0.0f)
                {
                    OpenResult(ResultType.GameOver);
                }

                await UniTask.Yield();
            }
        }

        /// <summary>
        /// インゲーム内の各タイマー計測
        /// </summary>
        /// <returns></returns>
        private async UniTask CountTimerHard()
        {
            _inGameTimer = 0.0f;

            while (!_isEndInGame)
            {
                _inGameTimer += Time.deltaTime;


                ConsumeEnergy();

                if (Context.MainEnergy <= 0.0f)
                {
                    OpenResult(ResultType.Clear);
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
        private void OpenResult(ResultType result)
        {
            Reset();
            _objectManager.DestroyAllObject();
            ScreenNavigator.Instance.ChangePage(new ResultPageController() { Type = result });

            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
    }
}
