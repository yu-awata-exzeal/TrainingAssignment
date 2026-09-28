using Manager;
using UnityEngine;

public class Fuel : MonoBehaviour, IInteractable
{
    private const float _intervalTime = 2.0f;
    private float _intervalTimer = 0.0f;
    /// <summary>
    /// 取得可能フラグ
    /// </summary>
    private bool _isCollectable = true;

    InteractType IInteractable.Type => InteractType.OnTriggerEnter;
    public static int Content => InGameSystem.Instance.CurrentStageSetting.FuelContent;

    private void Start()
    {
        _intervalTimer = _intervalTime;
    }

    private void Update()
    {

    }

    /// <summary>
    /// インタラクト処理
    /// </summary>
    /// <param name="context"></param>
    public void Interact(InteractionContext context)
    {
        if (context.InteractType == InteractType.OnTriggerEnter)
        {
            context.Inventory.ChatchFuel();
            FuelManager.Instance.RegisterUnActiveFuel(this);
        }
    }
}