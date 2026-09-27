using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    private class EnemyData
    {
        public Enemy Enemy { get; init; }
        public float RespawnTimer { get; set; }
    }
    public static EnemyManager Instance { get; private set; }

    private readonly List<EnemyData> _respawnItems = new();

    private readonly float IntervalTime = 2.0f; /*InGameSystem.Instance.CurrentStageSetting.*/

    private void Awake()
    {
        Instance = this;
    }

    public void ActivateEnemys(bool isActive)
    {
        foreach (var enemyData in _respawnItems)
        {
            enemyData.Enemy.gameObject.SetActive(isActive);
        }
    }

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
