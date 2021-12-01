/*************************************************************************
 *  Copyright © 2021 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  GameObjectPoolManager.cs
 *  Description  :  Manager of gameobject pool.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  1.0
 *  Date         :  2/9/2021
 *  Description  :  Initial development version.
 *************************************************************************/

using System.Collections.Generic;
using UnityEngine;

namespace MGS.DesignPattern
{
    /// <summary>
    /// Manager of gameobject pool.
    /// </summary>
    public sealed class GameObjectPoolManager : Singleton<GameObjectPoolManager>
    {
        /// <summary>
        /// Pools infos (name and pool).
        /// </summary>
        private Dictionary<string, GameObjectPool> poolInfos = new Dictionary<string, GameObjectPool>();

        /// <summary>
        /// Root transform for pools.
        /// </summary>
        private readonly Transform poolRoot;

        /// <summary>
        /// Constructor.
        /// </summary>
        private GameObjectPoolManager()
        {
            //Create the root node for pools.
            poolRoot = new GameObject(GetType().Name).transform;
            Object.DontDestroyOnLoad(poolRoot);
        }

        /// <summary>
        /// Create a pool in this manager.
        /// </summary>
        /// <param name="name">Name of pool.</param>
        /// <param name="prefab">Prefab of pool.</param>
        /// <param name="capacities">Capacities of object pool.</param>
        /// <returns>Pool created base on parameters.</returns>
        public GameObjectPool CreatePool(string name, GameObject prefab, int capacities = 100)
        {
            if (string.IsNullOrEmpty(name))
            {
                return null;
            }

            if (poolInfos.ContainsKey(name))
            {
                return poolInfos[name];
            }

            if (prefab == null)
            {
                return null;
            }

            //Create pool node.
            var poolNode = new GameObject(name).transform;
            poolNode.parent = poolRoot;

            //Create pool.
            var newPool = new GameObjectPool(poolNode, prefab, capacities);
            poolInfos.Add(name, newPool);
            return newPool;
        }

        /// <summary>
        /// Find GameObjectPool by name.
        /// </summary>
        /// <param name="name">Name of GameObjectPool.</param>
        /// <returns>Name match GameObjectPool.</returns>
        public GameObjectPool FindPool(string name)
        {
            if (poolInfos.ContainsKey(name))
            {
                return poolInfos[name];
            }
            return null;
        }

        /// <summary>
        /// Delete GameObjectPool by name.
        /// </summary>
        /// <param name="name">Name of GameObjectPool.</param>
        public void DeletePool(string name)
        {
            if (poolInfos.ContainsKey(name))
            {
                var pool = poolInfos[name];
                pool.Clear();

                Object.Destroy(pool.Node.gameObject);
                poolInfos.Remove(name);
            }
        }
    }
}