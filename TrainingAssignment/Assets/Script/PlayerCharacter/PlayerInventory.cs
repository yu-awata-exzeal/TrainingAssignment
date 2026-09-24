using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// プレイヤーの所持アイテム
/// </summary>
public class PlayerInventory : MonoBehaviour
{
    /// <summary>
    /// 燃料アイテム
    /// </summary>
    [SerializeField]
    private Fuel _fuel;
    /// <summary>
    /// 取得アイテムと所持数のリスト
    /// </summary>
    private Dictionary<string, int> itemList = new();

    /// <summary>
    /// 燃料アイテムを使用
    /// </summary>
    /// <param name="fuel"> 使用した燃料 </param>
    /// <returns></returns>
    public bool TryUseFuel(out Fuel fuel)
    {
        if (itemList.ContainsKey(nameof(Fuel))
            && itemList[nameof(Fuel)] > 0)
        {
            itemList[nameof(Fuel)]--;
            fuel = _fuel;
            return true;
        }

        fuel = null;
        return false;
    }

    /// <summary>
    /// 燃料アイテムを補充
    /// </summary>
    public void ChatchFuel()
    {
        itemList[nameof(Fuel)]++;
    }
}