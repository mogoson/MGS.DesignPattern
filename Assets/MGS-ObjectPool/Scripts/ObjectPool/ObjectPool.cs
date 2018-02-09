/*************************************************************************
 *  Copyright 2018 Mogoson All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  ObjectPool.cs
 *  Description  :  Define ObjectPool.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  0.1.0
 *  Date         :  2/9/2018
 *  Description  :  Initial development version.
 *************************************************************************/

using System;
using System.Collections.Generic;

namespace Developer.ObjectPool
{
    /// <summary>
    /// Generic object pool.
    /// </summary>
    /// <typeparam name="T">Type of objects in pool.</typeparam>
    public class ObjectPool<T>
    {
        #region Property and Field
        /// <summary>
        /// Max count limit of objects.
        /// </summary>
        public int MaxCount { set; get; }

        /// <summary>
        /// Current count of objects.
        /// </summary>
        public int CurrentCount { get { return objectStack.Count; } }

        /// <summary>
        /// Stack store objects.
        /// </summary>
        protected Stack<T> objectStack = new Stack<T>();

        /// <summary>
        /// Function of create new object.
        /// </summary>
        protected Func<T> createFunc;

        /// <summary>
        /// Action of reset object to default.
        /// </summary>
        protected Action<T> resetAction;

        /// <summary>
        /// Action of dispose object.
        /// </summary>
        protected Action<T> disposeAction;
        #endregion

        #region Public Method
        /// <summary>
        /// Constructor of ObjectPool.
        /// </summary>
        /// <param name="create">Function of create new object.</param>
        /// <param name="reset">Action of reset object to default.</param>
        /// <param name="dispose">Action of dispose object.</param>
        /// <param name="maxCount">Max count limit of objects.</param>
        public ObjectPool(Func<T> create, Action<T> reset, Action<T> dispose, int maxCount = 100)
        {
            createFunc = create;
            resetAction = reset;
            disposeAction = dispose;
            MaxCount = maxCount;
        }

        /// <summary>
        /// Take a new object from pool.
        /// </summary>
        /// <returns>New object.</returns>
        public virtual T TakeNew()
        {
            if (objectStack.Count > 0)
                return objectStack.Pop();
            else
            {
                if (createFunc == null)
                    return default(T);
                else
                    return createFunc.Invoke();
            }
        }

        /// <summary>
        /// Recycle object to pool.
        /// </summary>
        /// <param name="obj">Object to recycle.</param>
        public virtual void Recycle(T obj)
        {
            if (obj == null)
                return;

            if (objectStack.Count < MaxCount)
            {
                if (resetAction != null)
                    resetAction.Invoke(obj);

                objectStack.Push(obj);
            }
            else
            {
                if (disposeAction != null)
                    disposeAction.Invoke(obj);
            }
        }

        /// <summary>
        /// Clear all objects.  
        /// </summary>
        public virtual void Clear()
        {
            if (disposeAction != null)
            {
                foreach (var obj in objectStack)
                {
                    disposeAction.Invoke(obj);
                }
            }
            objectStack.Clear();
        }
        #endregion
    }
}