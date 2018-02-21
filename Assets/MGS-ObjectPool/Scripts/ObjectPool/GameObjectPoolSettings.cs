/*************************************************************************
 *  Copyright © 2018 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  GameObjectPoolSettings.cs
 *  Description  :  Settings of GameObjectPool.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  0.1.0
 *  Date         :  2/20/2018
 *  Description  :  Initial development version.
 *************************************************************************/

using System;
using UnityEngine;

namespace Developer.ObjectPool
{
    /// <summary>
    /// Settings of GameObjectPool.
    /// </summary>
    [Serializable]
    public struct GameObjectPoolSettings
    {
        #region Property and Field
        /// <summary>
        /// Type of pool.
        /// </summary>
        public GameObjectPoolType type;

        /// <summary>
        /// Prefab to create clone.
        /// </summary>
        public GameObject prefab;

        /// <summary>
        /// Max count limit of gameobjects in pool.
        /// </summary>
        public int maxCount;
        #endregion

        #region Public Method
        public GameObjectPoolSettings(GameObjectPoolType type, GameObject prefab, int maxCount = 100)
        {
            this.type = type;
            this.prefab = prefab;
            this.maxCount = maxCount;
        }
        #endregion
    }
}