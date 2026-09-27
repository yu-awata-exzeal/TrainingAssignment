using Manager;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// プレイヤーの所持アイテム
/// </summary>
public class PlayerInventory : MonoBehaviour
{
    /// <summary>
    /// 取得アイテムと所持数のリスト
    /// </summary>
    private Dictionary<string, int> itemList = new();

    /// <summary>
    /// 燃料アイテムを使用
    /// </summary>
    /// <param name="fuel"> 使用した燃料 </param>
    /// <returns></returns>
    public bool TryUseFuel(out int fuelContain)
    {
        if (itemList.ContainsKey(nameof(Fuel))
            && itemList[nameof(Fuel)] > 0)
        {
            itemList[nameof(Fuel)]--;
            InGameSystem.Context.SetFuelCount(itemList[nameof(Fuel)]);
            fuelContain = Fuel.Content;
            return true;
        }

        fuelContain = 0;
        return false;
    }

    /// <summary>
    /// 燃料アイテムを補充
    /// </summary>
    public void ChatchFuel()
    {
        if (!itemList.ContainsKey(nameof(Fuel)))
        {
            itemList.Add(nameof(Fuel), 0);
        }

        itemList[nameof(Fuel)]++;
        InGameSystem.Context.SetFuelCount(itemList[nameof(Fuel)]);
    }
}