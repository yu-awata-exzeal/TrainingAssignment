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

        private readonly List<EnemyData> _enemyList = new();

        private readonly float _respawnInterval = 2.0f;

        private void Awake()
        {
            Instance = this;
        }

        /// <summary>
        /// エネミーオブジェクトをアクティブ化
        /// </summary>
        /// <param name="isActive"></param>
        public void ActivateEnemies(bool isActive)
        {
            foreach (var enemyData in _enemyList)
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
            _enemyList.Add(
                new EnemyData()
                {
                    Enemy = enemy,
                    RespawnTimer = _respawnInterval,
                }
            );
            enemy.gameObject.SetActive(false);
        }
    }
}
