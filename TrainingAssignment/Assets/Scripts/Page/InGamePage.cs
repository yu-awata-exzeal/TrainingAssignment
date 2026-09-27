using Manager;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Page
{
    public class InGamePageContext : IContext
    {
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

        protected override void OnSetup()
        {
            _mainEnergyUI.maxValue = Context.InGameContext.MainEnergy;
            _subEnergyUI.maxValue = Context.InGameContext.AuxiliaryEnergy;
            _itemCountText.text = InGameSystem.Context.FuelCount.ToString();
        }

        private void Update()
        {
            UpdateEnergySlider();
            UpdateSurvivalTimerText();
        }

        private void UpdateSurvivalTimerText()
        {
            var second = InGameSystem.Instance.SurvivaleTimer % _secondParMinute;

            _itemCountText.text = InGameSystem.Context.FuelCount.ToString();
            _minutesText.text = _minutesCounter.ToString("0");
            _secondText.text = second.ToString("0");

            if (second >= _secondParMinute - 1)
            {
                _minutesCounter++;
            }
        }

        private void UpdateEnergySlider()
        {
            _mainEnergyUI.value = Context.InGameContext.MainEnergy;
            _subEnergyUI.value = Context.InGameContext.AuxiliaryEnergy;
        }
    }
}