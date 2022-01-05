/*************************************************************************
 *  Copyright © 2021 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  GameObjectPool.cs
 *  Description  :  Define GameObjectPool.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  1.0
 *  Date         :  2/9/2021
 *  Description  :  Initial development version.
 *************************************************************************/

using UnityEngine;

namespace MGS.DesignPattern
{
    /// <summary>
    /// Object pool for GameObject.
    /// </summary>
    public class GameObjectPool : ObjectPool<GameObject>
    {
        /// <summary>
        /// Parent of gameobjects.
        /// </summary>
        public Transform Node { protected set; get; }

        /// <summary>
        /// Prefab to create clone.
        /// </summary>
        protected GameObject prefab;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="node">Parent of gameobjects.</param>
        /// <param name="prefab">Prefab to create clone.</param>
        /// <param name="capacities">Capacities of object pool.</param>
        public GameObjectPool(Transform node, GameObject prefab, int capacities = 100) : base(capacities)
        {
            Node = node;
            this.prefab = prefab;
        }

        /// <summary>
        /// Take a gameobject from pool.
        /// </summary>
        /// <returns>A gameobject.</returns>
        public override GameObject Take()
        {
            var obj = base.Take();
            obj.SetActive(true);
            return obj;
        }

        /// <summary>
        /// Take a gameobject from pool and get the specified component.
        /// </summary>
        /// <typeparam name="T">Specified type of component.</typeparam>
        /// <returns></returns>
        public virtual T Take<T>() where T : Component
        {
            var obj = Take();
            var cpnt = obj.GetComponent<T>();
            if (cpnt == null)
            {
                cpnt = obj.AddComponent<T>();
            }
            return cpnt;
        }

        /// <summary>
        /// Recycle the game object of component to pool.
        /// </summary>
        /// <param name="cpnt">Instance of component.</param>
        public virtual void Recycle(Component cpnt)
        {
            if (cpnt == null)
            {
                return;
            }

            Recycle(cpnt.gameObject);
        }

        /// <summary>
        /// Create new gameobject.
        /// </summary>
        /// <returns></returns>
        protected override GameObject Create()
        {
            var clone = Object.Instantiate(prefab);
            clone.transform.parent = Node;
            return clone;
        }

        /// <summary>
        /// Reset the gameobject.
        /// </summary>
        /// <param name="obj"></param>
        protected override void Reset(GameObject obj)
        {
            obj.SetActive(false);

            obj.tag = prefab.tag;
            obj.layer = prefab.layer;

            obj.transform.position = prefab.transform.position;
            obj.transform.rotation = prefab.transform.rotation;

            obj.transform.parent = null;
            obj.transform.localScale = prefab.transform.localScale;
            obj.transform.parent = Node;
        }

        /// <summary>
        /// Dispose the gameobject.
        /// </summary>
        /// <param name="obj"></param>
        protected override void Dispose(GameObject obj)
        {
            Object.Destroy(obj);
        }
    }
}