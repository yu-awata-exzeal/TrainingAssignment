using UnityEngine;
using UnityEngine.UI;

public class BasePoint : MonoBehaviour, IInteractable
{
    [SerializeField]
    private StageSettings _currentStageSetting;
    [SerializeField]
    private Slider _energySlider;

    /// <summary>
    /// 現在のエネルギー量
    /// </summary>
    private float _currntEnergyContent = 0;
    float _timer = 0.0f;
    InteractType IInteractable.Type => InteractType.ButtonInput;

    void Start()
    {

        _currntEnergyContent = _currentStageSetting.MaxBasePointEnergy;
    }

    void Update()
    {
        UpdateEnecgyGage();
    }

    private void UpdateEnecgyGage()
    {
        _timer += Time.deltaTime;

        if (_timer > 1.0f)
        {
            _currntEnergyContent -= _currentStageSetting.EnergyConsumptionRate;
            _timer = 0.0f;
        }

        float energyRadio = (_currntEnergyContent / _currentStageSetting.MaxBasePointEnergy);
        _energySlider.value = energyRadio;
    }

    public void Interact(InteractionContext context)
    {
        if (!context.Inventory.TryUseFuel(out var item))
        {
            return;
        }

        //回復
        _currntEnergyContent += item.Content;
    }
}
