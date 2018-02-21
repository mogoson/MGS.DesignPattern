/*************************************************************************
 *  Copyright © 2018 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  GameObjectPoolManager.cs
 *  Description  :  Manager of gameobject pool.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  0.1.0
 *  Date         :  2/9/2018
 *  Description  :  Initial development version.
 *************************************************************************/

using System.Collections.Generic;
using Developer.Singleton;
using UnityEngine;

namespace Developer.ObjectPool
{
    [AddComponentMenu("Developer/ObjectPool/GameObjectPoolManager")]
    public sealed class GameObjectPoolManager : SingleMonoBehaviour<GameObjectPoolManager>
    {
        #region Property and Field
        /// <summary>
        /// Settings of pools.
        /// </summary>
        [SerializeField]
        private List<GameObjectPoolSettings> poolsSettings = new List<GameObjectPoolSettings>();

        /// <summary>
        /// Dictionary store pools info(type and pool).
        /// </summary>
        private Dictionary<GameObjectPoolType, GameObjectPool> poolsInfo = new Dictionary<GameObjectPoolType, GameObjectPool>();
        #endregion

        #region Protected Method
        protected override void SingleAwake()
        {
            foreach (var poolSettings in poolsSettings)
            {
#if UNITY_EDITOR
                if (poolsInfo.ContainsKey(poolSettings.type))
                    Debug.LogErrorFormat("The type {0} of GameObjectPool configured in the Pools Settings is not unique in this manager.", poolSettings.type);
                else
#endif
                    CreatePool(poolSettings);
            }
        }
        #endregion

        #region Public Method
        /// <summary>
        /// Create a pool in this manager.
        /// </summary>
        /// <param name="type">Type of GameObjectPool.</param>
        /// <param name="prefab">Prefab of GameObjectPool.</param>
        /// <param name="maxCount">Max count limit of gameobjects in pool.</param>
        /// <returns>Pool created base on parameters.</returns>
        public GameObjectPool CreatePool(GameObjectPoolType type, GameObject prefab, int maxCount = 100)
        {
            if (poolsInfo.ContainsKey(type))
            {
                Debug.LogWarningFormat("Create pool is failed : The pool that type is {0} already exist in this manager.", type);
                return poolsInfo[type];
            }

            if (prefab == null)
            {
                Debug.LogError("Create pool is failed : The prefab of pool can not be null.");
                return null;
            }

            //Create new root for pool.
            var poolRoot = new GameObject(prefab.name + "Pool");
            poolRoot.transform.parent = transform;

            //Create new pool.
            var newPool = new GameObjectPool(poolRoot.transform, prefab, maxCount);
            poolsInfo.Add(type, newPool);

#if UNITY_EDITOR
            var newPoolSettings = new GameObjectPoolSettings(type, prefab, maxCount);
            if (!poolsSettings.Contains(newPoolSettings))
                poolsSettings.Add(newPoolSettings);
#endif
            return newPool;
        }

        /// <summary>
        /// Create a pool in this manager.
        /// </summary>
        /// <param name="poolSettings">Settings of pool.</param>
        /// <returns>Pool created base on settings.</returns>
        public GameObjectPool CreatePool(GameObjectPoolSettings poolSettings)
        {
            return CreatePool(poolSettings.type, poolSettings.prefab, poolSettings.maxCount);
        }

        /// <summary>
        /// Find GameObjectPool by type.
        /// </summary>
        /// <param name="type">Type of GameObjectPool.</param>
        /// <returns>Type match GameObjectPool.</returns>
        public GameObjectPool FindPool(GameObjectPoolType type)
        {
            if (poolsInfo.ContainsKey(type))
                return poolsInfo[type];
            else
            {
                Debug.LogWarningFormat("Find pool is failed : The pool that type is {0} does not exist in this manager.", type);
                return null;
            }
        }

        /// <summary>
        /// Delete GameObjectPool by type.
        /// </summary>
        /// <param name="type">Type of GameObjectPool.</param>
        /// <returns>Delete succeed.</returns>
        public bool DeletePool(GameObjectPoolType type)
        {
            if (poolsInfo.ContainsKey(type))
            {
                Destroy(poolsInfo[type].root.gameObject);
                poolsInfo.Remove(type);

#if UNITY_EDITOR
                foreach (var poolSettings in poolsSettings)
                {
                    if (poolSettings.type == type)
                    {
                        poolsSettings.Remove(poolSettings);
                        break;
                    }
                }
#endif
                return true;
            }
            else
            {
                Debug.LogWarningFormat("Delete pool is failed : The pool that type is {0} does not exist in this manager.", type);
                return false;
            }
        }
        #endregion
    }
}