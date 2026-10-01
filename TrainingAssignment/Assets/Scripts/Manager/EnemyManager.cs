using System.Collections.Generic;
using UnityEngine;

namespace Manager
{
    public class EnemyManager : MonoBehaviour
    {
        private class EnemyData
        {
            /// <summary>
            /// エネミーオブジェクト
            /// </summary>
            public Enemy Enemy { get; init; }
            /// <summary>
            /// 活動再開タイマー
            /// </summary>
            public float RespawnTimer { get; set; }
        }

        public static EnemyManager Instance { get; private set; }

        private readonly List<EnemyData> _respawnItems = new();

        private readonly float IntervalTime = 2.0f; /*InGameSystem.Instance.CurrentStageSetting.*/

        private void Awake()
        {
            Instance = this;
        }

        /// <summary>
        /// エネミーオブジェクトをアクティブ化
        /// </summary>
        /// <param name="isActive"></param>
        public void ActivateEnemys(bool isActive)
        {
            foreach (var enemyData in _respawnItems)
            {
                enemyData.Enemy.gameObject.SetActive(isActive);
            }
        }

        /// <summary>
        /// 管理するエネミーオブジェクトを登録
        /// </summary>
        /// <param name="enemy"></param>
        public void Register(Enemy enemy)
        {
            _respawnItems.Add(
                new EnemyData()
                {
                    Enemy = enemy,
                    RespawnTimer = IntervalTime,
                }
            );
            enemy.gameObject.SetActive(false);
        }
    }
}
