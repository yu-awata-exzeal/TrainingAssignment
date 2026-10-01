using System.Collections.Generic;
using UnityEngine;

namespace Manager
{
    /// <summary>
    /// 燃料アイテムの管理クラス
    /// </summary>
    public class FuelManager : MonoBehaviour
    {
        private class FuelData
        {
            public Fuel Fuel { get; init; }
            public float RespawnTimer { get; set; }
        }
        public static FuelManager Instance { get; private set; }

        private readonly List<FuelData> _inactiveFuelList = new();

        private readonly float _respawnInterval = 10.0f;

        private void Awake()
        {
            Instance = this;
        }

        private void Update()
        {
            for (int i = _inactiveFuelList.Count - 1; i >= 0; i--)
            {
                var fuelData = _inactiveFuelList[i];

                if (fuelData.RespawnTimer > 0.0f)
                {
                    fuelData.RespawnTimer -= Time.deltaTime;
                    continue;
                }

                fuelData.Fuel.gameObject.SetActive(true);

                _inactiveFuelList.Remove(fuelData);
            }
        }

        /// <summary>
        /// 非アクティブとなるアイテムを登録
        /// </summary>
        /// <param name="item"></param>
        public void RegisterInactiveFuel(Fuel item)
        {
            _inactiveFuelList.Add(
                new FuelData()
                {
                    Fuel = item,
                    RespawnTimer = _respawnInterval,
                }
            );
            item.gameObject.SetActive(false);
        }
    }
}
