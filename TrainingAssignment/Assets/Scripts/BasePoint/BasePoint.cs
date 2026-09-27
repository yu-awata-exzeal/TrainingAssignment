using Manager;
using UnityEngine;

public class BasePoint : MonoBehaviour, IInteractable
{
    [SerializeField]
    private StageSettings _currentStageSetting;

    /// <summary>
    /// 現在のエネルギー量
    /// </summary>
    private float _currntEnergyContent = 0;
    private float _timer = 0.0f;
    InteractType IInteractable.Type => InteractType.ButtonInput;

    /// <summary>
    /// 現在のエネルギー量
    /// </summary>
    public float CurrentEnelgyContent => _currntEnergyContent;

    void Start()
    {
        _currentStageSetting = InGameSystem.Instance.CurrentStageSetting;
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
    }

    public void Interact(InteractionContext context)
    {
        if (!context.Inventory.TryUseFuel(out var contain))
        {
            return;
        }

        Debug.Log($"[{nameof(BasePoint)}] インタラクト");

        //回復
        _currntEnergyContent += contain;
    }
}
