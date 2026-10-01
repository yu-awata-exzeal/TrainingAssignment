using Manager;
using System.Collections.Generic;
using UnityEngine;

public class InGameObjectManager
{
    private class InGameObjectEntry
    {
        /// <summary>
        /// 登録しているオブジェクト
        /// </summary>
        public GameObject Object { get; init; }
        /// <summary>
        /// オブジェクトのプレハブパス
        /// </summary>
        public string Path { get; init; }
    }

    private readonly List<InGameObjectEntry> _objectList = new();

    /// <summary>
    /// 指定したコンポーネント名のプレハブを生成
    /// ※プレハブ名はコンポーネント名と同一
    /// </summary>
    /// <typeparam name="TComponent"></typeparam>
    public void CreateObject<TComponent>(Vector3 position, Quaternion rotation) where TComponent : Component
    {
        var newObject
            = ResourceManager.InstantiatePrefab<TComponent>(
                position,
                rotation,
                $"Prefabs/{typeof(TComponent).Name}");

        _objectList.Add(new()
        {
            Object = newObject.gameObject,
            Path = $"Prefabs/{typeof(TComponent).Name}",
        });

        newObject.transform.parent = ScreenNavigator.Instance.WorldScope;
    }

    /// <summary>
    /// 登録してあるオブジェクトをすべて削除
    /// </summary>
    public void DestroyAllObjects()
    {
        foreach (var objData in _objectList)
        {
            ResourceManager.RemovePrefabCache(objData.Path);
            Object.Destroy(objData.Object);
        }
        _objectList.Clear();
    }
}
