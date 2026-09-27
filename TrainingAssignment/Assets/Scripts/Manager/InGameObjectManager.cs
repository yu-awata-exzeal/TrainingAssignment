using Manager;
using System.Collections.Generic;
using UnityEngine;

public class InGameObjectManager
{
    private class InGameObjectData
    {
        public GameObject Object { get; init; }
        public string Path { get; init; }
    }

    private List<InGameObjectData> _objectList = new();
    private Transform _worldScope;

    /// <summary>
    /// 指定したコンポーネントを持つプレハブを生成
    /// ※プレハブ名はコンポーネントと同名
    /// </summary>
    /// <typeparam name="TComponent"></typeparam>
    public void CreateObject<TComponent>() where TComponent : Component
    {
        var newObject = ResourceManager.InstantiatePrefab<TComponent>($"Prefabs/{typeof(TComponent).Name}");
        newObject.transform.parent = ScreenNavigator.Instance.WorldScope;

        _objectList.Add(new()
        {
            Object = newObject.gameObject,
            Path = $"Prefabs/{typeof(TComponent).Name}",
        });

        newObject.transform.parent = _worldScope;
    }

    public void DestroyAllObject()
    {
        foreach (var objData in _objectList)
        {
            ResourceManager.UnloadPrefab(objData.Path);
            Object.Destroy(objData.Object);
        }
        _objectList.Clear();
    }
}
