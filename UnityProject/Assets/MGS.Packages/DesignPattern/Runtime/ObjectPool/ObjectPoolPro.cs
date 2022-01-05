/*************************************************************************
 *  Copyright © 2021 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  ObjectPoolPro.cs
 *  Description  :  Object pool pro.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  1.0
 *  Date         :  7/4/2021
 *  Description  :  Initial development version.
 *************************************************************************/

using System;

namespace MGS.DesignPattern
{
    /// <summary>
    /// Interface for resettable object.
    /// </summary>
    public interface IResettable : IDisposable
    {
        /// <summary>
        /// Reset object.
        /// </summary>
        void Reset();
    }

    /// <summary>
    /// Object pool for resettable object.
    /// </summary>
    /// <typeparam name="T">Specified type of object.</typeparam>
    public class ObjectPoolPro<T> : ObjectPool<T> where T : IResettable, new()
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="capacities">Capacities of object pool.</param>
        public ObjectPoolPro(int capacities = 100) : base(capacities) { }

        /// <summary>
        /// Create a new object.
        /// </summary>
        /// <returns></returns>
        protected override T Create()
        {
            return new T();
        }

        /// <summary>
        /// Reset this object.
        /// </summary>
        /// <param name="obj"></param>
        protected override void Reset(T obj)
        {
            obj.Reset();
        }

        /// <summary>
        /// Dispose this object.
        /// </summary>
        /// <param name="obj"></param>
        protected override void Dispose(T obj)
        {
            obj.Dispose();
        }
    }
}