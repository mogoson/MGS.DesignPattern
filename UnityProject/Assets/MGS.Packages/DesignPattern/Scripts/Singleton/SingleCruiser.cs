/*************************************************************************
 *  Copyright © 2021 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  SingleCruiser.cs
 *  Description  :  Define single cruiser.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  1.0
 *  Date         :  6/4/2021
 *  Description  :  Initial development version.
 *************************************************************************/

using System.Threading;

namespace MGS.DesignPattern
{
    /// <summary>
    /// Provide a lazy and thread safety single instance of the specified type T with thread cruise;
    /// Specified type T should with the sealed access modifier
    /// and a private parameterless constructor to ensure singleton.
    /// </summary>
    /// <typeparam name="T">Specified type.</typeparam>
    public abstract class SingleCruiser<T> : Singleton<T> where T : class
    {
        /// <summary>
        /// Cruiser is active?
        /// </summary>
        public bool IsActive { set; get; }

        /// <summary>
        /// Interval of cruiser run time (ms).
        /// </summary>
        public int Interval { set; get; }

        /// <summary>
        /// Constructor.
        /// </summary>
        protected SingleCruiser()
        {
            IsActive = true;
            Interval = 200;
            new Thread(ThreadCruise) { IsBackground = true }.Start();
        }

        /// <summary>
        /// Thread cruise.
        /// </summary>
        private void ThreadCruise()
        {
            while (true)
            {
                if (IsActive)
                {
                    Cruise();
                }
                Thread.Sleep(Interval);
            }
        }

        /// <summary>
        /// Execute cruise.
        /// </summary>
        protected abstract void Cruise();
    }
}