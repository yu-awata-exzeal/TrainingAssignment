using Manager;
using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Page
{
    /// <summary>
    /// インゲームUIのコンテキスト
    /// </summary>
    public class InGamePageContext : IContext
    {
        public Action OnOpenOption { get; set; }
        public InGameContext InGameContext { get; init; }
        public StageSettings StageSetting { get; init; }
    }

    public class InGamePage : PageBase<InGamePageContext>
    {
        [SerializeField]
        private TextMeshProUGUI _itemCountText;
        [SerializeField]
        private TextMeshProUGUI _minutesText;
        [SerializeField]
        private TextMeshProUGUI _secondsText;
        [SerializeField]
        private Slider _mainEnergy;
        [SerializeField]
        private Slider _subEnergy;
        [SerializeField]
        private GameObject _minimap;

        private readonly float _secondsParMinute = 60;
        private float _minutes = 0.0f;
        private float _seconds = 0.0f;
        private bool _isMinuteDecremented = true;

        protected override void OnSetup()
        {
            _mainEnergy.maxValue = Context.InGameContext.MainEnergy;
            _subEnergy.maxValue = Context.InGameContext.AuxiliaryEnergy;
            _itemCountText.text = InGameSystem.Context.FuelCount.ToString();

            _minutes = InGameSystem.Instance.SurvivalTimer / _secondsParMinute;
            _seconds = InGameSystem.Instance.SurvivalTimer % _secondsParMinute;
        }

        private void Update()
        {
            UpdateEnergySlider();
            UpdateSurvivalTimerText();

            Context.OnOpenOption?.Invoke();
            _itemCountText.text = InGameSystem.Context.FuelCount.ToString();
            _minimap.SetActive(Context.InGameContext.AuxiliaryEnergy > 0.0f);
        }

        /// <summary>
        /// 生存時間の計測
        /// </summary>
        private void UpdateSurvivalTimerText()
        {
            _seconds = InGameSystem.Instance.SurvivalTimer % _secondsParMinute;

            _minutesText.text = _minutes.ToString("0");
            _secondsText.text = _seconds.ToString("00");

            if (_seconds >= _secondsParMinute - 1)
            {
                if (_isMinuteDecremented)
                {
                    _minutes--;
                    _isMinuteDecremented = false;
                }
            }
            else
            {
                _isMinuteDecremented = true;
            }
        }

        private void UpdateEnergySlider()
        {
            _mainEnergy.value = Context.InGameContext.MainEnergy;
            _subEnergy.value = Context.InGameContext.AuxiliaryEnergy;
        }
    }
}