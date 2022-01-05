/*************************************************************************
 *  Copyright © 2021 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  SingleComponent.cs
 *  Description  :  Define single component.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  1.0
 *  Date         :  7/11/2021
 *  Description  :  Initial development version.
 *************************************************************************/

using UnityEngine;

namespace MGS.DesignPattern
{
    /// <summary>
    /// Provide a auto create, lazy and thread safety single instance of the specified component T;
    /// Specified component T should with the sealed access modifier to ensure singleton.
    /// Do not add the component T to any gameobject by yourself.
    /// </summary>
    /// <typeparam name="T">Specified type.</typeparam>
    [DisallowMultipleComponent]
    public abstract class SingleComponent<T> : MonoBehaviour where T : Component
    {
        /// <summary>
        /// Single instance of the specified component T (Lazy).
        /// </summary>
        public static T Instance { get { return Agent.instance; } }

        /// <summary>
        /// Agent provide the single instance.
        /// </summary>
        private class Agent
        {
            /// <summary>
            /// Single instance of the specified component T (Thread safety).
            /// </summary>
            internal static readonly T instance = new GameObject(typeof(T).Name).AddComponent<T>();

            /// <summary>
            /// Explicit static constructor to tell C# compiler not to mark type as beforefieldinit.
            /// </summary>
            static Agent() { DontDestroyOnLoad(instance); }
        }
    }
}