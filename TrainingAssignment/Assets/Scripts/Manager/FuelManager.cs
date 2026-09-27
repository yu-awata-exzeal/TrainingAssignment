using System.Collections.Generic;
using UnityEngine;

public class FuelManager : MonoBehaviour
{
    private class ItemData
    {
        public Fuel Fuel { get; init; }
        public float RespawnTimer { get; set; }
    }
    public static FuelManager Instance { get; private set; }

    private readonly List<ItemData> _respawnItems = new();

    private readonly float IntervalTime = 2.0f; /*InGameSystem.Instance.CurrentStageSetting.*/

    private void Awake()
    {
        Instance = this;
    }

    private void Update()
    {
        float currentTime = Time.time;

        for (int i = _respawnItems.Count - 1; i >= 0; i--)
        {
            var fuelData = _respawnItems[i];

            if (fuelData.RespawnTimer > 0.0f)
            {
                fuelData.RespawnTimer -= Time.deltaTime;
                continue;
            }

            fuelData.Fuel.gameObject.SetActive(true);

            _respawnItems.Remove(fuelData);
        }
    }

    public void RegisterUnActiveFuel(Fuel item)
    {
        _respawnItems.Add(
            new ItemData()
            {
                Fuel = item,
                RespawnTimer = IntervalTime,
            }
        );
        item.gameObject.SetActive(false);
    }
}
