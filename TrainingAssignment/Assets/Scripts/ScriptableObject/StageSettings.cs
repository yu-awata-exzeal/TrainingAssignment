using UnityEngine;

[CreateAssetMenu(menuName = "StageSettings")]
public class StageSettings : ScriptableObject
{
    /// <summary>
    /// 生存時間の制限時間
    /// </summary>
    public float SurvivalTimeLimit;
    /// <summary>
    /// 行動不能状態の継続時間
    /// </summary>
    public float EnemyIncapacitatedDuration;
    /// <summary>
    /// 拠点のエネルギー量上限
    /// </summary>
    public int MaxBasePointEnergy;
    /// <summary>
    /// プレイヤー携帯のエネルギー量
    /// </summary>
    public int MaxPlayerEnergy;
    /// <summary>
    /// 時間経過のエネルギー消費量
    /// </summary>
    public int EnergyConsumptionRate;
    /// <summary>
    /// 燃料アイテムのエネルギー回復量
    /// </summary>
    public int FuelEnergyAmount;
    /// <summary>
    /// 敵が出現するか
    /// </summary>
    public bool EnableEnemy;
}
