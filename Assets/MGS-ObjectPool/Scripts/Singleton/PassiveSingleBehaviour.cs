/*************************************************************************
 *  Copyright 2018 Mogoson All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  PassiveSingleBehaviour.cs
 *  Description  :  Define PassiveSingleBehaviour.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  0.1.0
 *  Date         :  2/10/2018
 *  Description  :  Initial development version.
 *************************************************************************/

using UnityEngine;

namespace Developer.Singleton
{
    public abstract class PassiveSingleBehaviour<T> : MonoBehaviour where T : PassiveSingleBehaviour<T>
    {
        #region Property and Field
        /// <summary>
        /// Makes this gameobject not be destroyed automatically when loading a new scene.
        /// </summary>
        [SerializeField]
        protected bool dontDestroyOnLoad = false;

        /// <summary>
        /// Instance of this class.
        /// </summary>
        public static T Instance { protected set; get; }
        #endregion

        #region Protected Method
        protected void Awake()
        {
            if (Instance == null)
            {
                Instance = (T)this;
                SingleAwake();

                if (dontDestroyOnLoad)
                    DontDestroyOnLoad(gameObject);
            }
            else if (Instance != this)
            {
                Destroy(this);
                Debug.LogWarningFormat("Destroy the redundant instance of {0} component form {1} : " +
                    "Multi instances of {0} component in a scene is violat singleton design.", typeof(T).Name, name);
            }
        }

        protected virtual void SingleAwake() { }
        #endregion
    }
}