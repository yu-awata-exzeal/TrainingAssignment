using System.Collections.Generic;
using UnityEngine;

namespace Manager
{
    /// <summary>
    ///　
    /// </summary>
    public class ResourceManager
    {
        private static Dictionary<string, GameObject> _prefabs = new();

        /// <summary>
        /// 指定したパスのプレハブを取得
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        static public T InstantiatePrefab<T>(string path) where T : Component
        {
            var prefab = LoadPrefab<T>(path);

            return prefab != null ? Object.Instantiate<T>(prefab) : null;
        }

        /// <summary>
        /// 指定したパスのプレハブをアンロード
        /// </summary>
        /// <param name="path"></param>
        static public void UnloadPrefab(string path)
        {
            if (string.IsNullOrEmpty(path)
                || !_prefabs.ContainsKey(path))
                return;

            _prefabs.Remove(path);
        }

        /// <summary>
        /// 指定したパスのプレハブをロード
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        static private T LoadPrefab<T>(string path) where T : Component
        {
            if (string.IsNullOrEmpty(path))
                return null;

            if (_prefabs.TryGetValue(path, out var prefab))
                return prefab.GetComponent<T>();

            prefab = Resources.Load<GameObject>(path);

            if (prefab == null)
            {
                Debug.LogError($"Prefabが見つかりません : {path}");
            }

            _prefabs.Add(path, prefab);
            return prefab.GetComponent<T>();
        }
    }
}
