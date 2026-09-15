using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    [SerializeField]
    private Fuel _fuel;
    [SerializeField]
    private InteractionDetector _interactionDetector;

    private Dictionary<string, int> itemList = new();

    /// <summary>
    /// 燃料アイテムを使用
    /// </summary>
    /// <param name="fuel"> 使用した燃料 </param>
    /// <returns></returns>
    public bool TryUseFuel(out Fuel fuel)
    {
        if (itemList.ContainsKey(nameof(Fuel))
            || itemList[nameof(Fuel)] > 0)
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