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

using System;
using System.Collections.Generic;
using Developer.Singleton;
using UnityEngine;

namespace Developer.ObjectPool
{
    [AddComponentMenu("Developer/ObjectPool/GameObjectPoolManager")]
    public class GameObjectPoolManager : SingleMonoBehaviour<GameObjectPoolManager>
    {
        #region Property and Field
        /// <summary>
        /// Dictionary store type and pool.
        /// </summary>
        protected Dictionary<GameObjectPoolType, GameObjectPool> poolDictionary = new Dictionary<GameObjectPoolType, GameObjectPool>();
        #endregion

        #region Protected Method
        protected override void SingleAwake()
        {
            RefreshPoolDictionary();
        }

        /// <summary>
        /// Refresh the Dictionary of pool.
        /// </summary>
        protected virtual void RefreshPoolDictionary()
        {
            poolDictionary.Clear();
            var pools = GetComponentsInChildren<GameObjectPool>();
            foreach (var pool in pools)
            {
                if (poolDictionary.ContainsKey(pool.type))
                    Debug.LogErrorFormat("The type of GameObjectPool component attached on the {0} is not unique.", pool.name);
                else
                    poolDictionary.Add(pool.type, pool);
            }
        }
        #endregion

        #region Public Method
        /// <summary>
        /// Get GameObjectPool by type.
        /// </summary>
        /// <param name="type">Type of GameObjectPool.</param>
        /// <returns>Type match GameObjectPool.</returns>
        public virtual GameObjectPool GetPoolByType(GameObjectPoolType type)
        {
            if (poolDictionary.ContainsKey(type))
                return poolDictionary[type];
            else
            {
                Debug.LogWarningFormat("Can not find the GameObjectPool in this manager : type is GameObjectPoolType.{0}.", type.ToString());
                return null;
            }
        }
        #endregion
    }
}