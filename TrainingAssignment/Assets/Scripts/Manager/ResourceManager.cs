using System.Collections.Generic;
using UnityEngine;

namespace Manager
{
    /// <summary>
    /// リソース生成・管理クラス
    /// </summary>
    public class ResourceManager
    {
        private static readonly Dictionary<string, GameObject> _prefabs = new();

        /// <summary>
        /// 指定したパスのプレハブを生成
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static T InstantiatePrefab<T>(Vector3 position, Quaternion rotation, string path) where T : Component
        {
            var prefab = LoadPrefab<T>(path);

            return prefab != null ? Object.Instantiate(prefab, position, rotation) : null;
        }

        /// <summary>
        /// 指定したパスのプレハブをキャッシュから削除
        /// </summary>
        /// <param name="path"></param>
        public static void RemovePrefabCache(string path)
        {
            if (string.IsNullOrEmpty(path))
                return;

            _prefabs.Remove(path);
        }

        /// <summary>
        /// 指定したパスのプレハブをロード
        /// </summary>
        /// <param name="path"></param>
        /// <returns>指定したパスのプレハブアセット</returns>
        private static T LoadPrefab<T>(string path) where T : Component
        {
            if (string.IsNullOrEmpty(path))
                return null;

            if (_prefabs.TryGetValue(path, out var prefab))
                return prefab.GetComponent<T>();

            prefab = Resources.Load<GameObject>(path);

            if (prefab == null)
            {
                Debug.LogError($"Prefabが見つかりません : {path}");
                return null;
            }

            _prefabs.Add(path, prefab);
            return prefab.GetComponent<T>();
        }
    }
}
