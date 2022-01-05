/*************************************************************************
 *  Copyright © 2021 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  SingleBehaviour.cs
 *  Description  :  Single behaviour.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  1.0
 *  Date         :  7/11/2021
 *  Description  :  Initial development version.
 *************************************************************************/

using System;

namespace MGS.DesignPattern
{
    /// <summary>
    /// Provide a auto create, lazy and thread safety single instance of behaviour.
    /// Do not add this component to any gameobject by yourself.
    /// </summary>
    public sealed class SingleBehaviour : SingleComponent<SingleBehaviour>
    {
        /// <summary>
        /// Event on application focus.
        /// </summary>
        public event Action<bool> OnApplicationFocusEvent;

        /// <summary>
        /// Event on application pause.
        /// </summary>
        public event Action<bool> OnApplicationPauseEvent;

        /// <summary>
        /// Event on application quit.
        /// </summary>
        public event Action OnApplicationQuitEvent;

        /// <summary>
        /// On application focus.
        /// </summary>
        /// <param name="hasFocus"></param>
        void OnApplicationFocus(bool hasFocus)
        {
            if (OnApplicationFocusEvent != null)
            {
                OnApplicationFocusEvent.Invoke(hasFocus);
            }
        }

        /// <summary>
        /// On application pause.
        /// </summary>
        /// <param name="pauseStatus"></param>
        void OnApplicationPause(bool pauseStatus)
        {
            if (OnApplicationPauseEvent != null)
            {
                OnApplicationPauseEvent.Invoke(pauseStatus);
            }
        }

        /// <summary>
        /// On application quit.
        /// </summary>
        void OnApplicationQuit()
        {
            if (OnApplicationQuitEvent != null)
            {
                OnApplicationQuitEvent.Invoke();
            }
        }
    }
}