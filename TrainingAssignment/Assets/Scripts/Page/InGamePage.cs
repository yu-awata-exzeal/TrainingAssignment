using Manager;
using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Page
{
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
        private TextMeshProUGUI _secondText;
        [SerializeField]
        private Slider _mainEnergyUI;
        [SerializeField]
        private Slider _subEnergyUI;

        private readonly float _secondParMinute = 60;
        private float _minutesCounter = 0.0f;
        private float _secondsCounter = 0.0f;
        private bool _subMinute = true;

        protected override void OnSetup()
        {
            _mainEnergyUI.maxValue = Context.InGameContext.MainEnergy;
            _subEnergyUI.maxValue = Context.InGameContext.AuxiliaryEnergy;
            _itemCountText.text = InGameSystem.Context.FuelCount.ToString();
            _minutesCounter = InGameSystem.Instance.SurvivaleTimer / _secondParMinute;
            _secondsCounter = InGameSystem.Instance.SurvivaleTimer % _secondParMinute;
        }

        private void Update()
        {
            UpdateEnergySlider();
            UpdateSurvivalTimerText();

            Context.OnOpenOption.Invoke();
        }

        /// <summary>
        /// ê∂ë∂éûä‘ÇÃåvë™
        /// </summary>
        private void UpdateSurvivalTimerText()
        {
            _secondsCounter = InGameSystem.Instance.SurvivaleTimer % _secondParMinute;

            _itemCountText.text = InGameSystem.Context.FuelCount.ToString();
            _minutesText.text = _minutesCounter.ToString("0");
            _secondText.text = _secondsCounter.ToString("0");

            if (_secondsCounter >= _secondParMinute - 1)
            {
                if (_subMinute)
                {
                    _minutesCounter--;
                    _subMinute = false;
                }
            }
            else
            {
                _subMinute = true;
            }
        }

        private void UpdateEnergySlider()
        {
            _mainEnergyUI.value = Context.InGameContext.MainEnergy;
            _subEnergyUI.value = Context.InGameContext.AuxiliaryEnergy;
        }
    }
}