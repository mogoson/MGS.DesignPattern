/*************************************************************************
 *  Copyright © 2018 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  Bullet.cs
 *  Description  :  Define bullet for demo.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  0.1.0
 *  Date         :  2/9/2018
 *  Description  :  Initial development version.
 *************************************************************************/

using System.Collections;
using UnityEngine;

namespace Developer.ObjectPool
{
    [AddComponentMenu("Developer/ObjectPool/Bullet")]
    [RequireComponent(typeof(Rigidbody))]
    public class Bullet : MonoBehaviour
    {
        #region Property and Field
        public GameObjectPoolType poolType;
        public float destroyDelay = 3;

        private new Rigidbody rigidbody;
        private GameObjectPool dependentPool;
        #endregion

        #region Private Method
        private void Awake()
        {
            rigidbody = GetComponent<Rigidbody>();
            dependentPool = GameObjectPoolManager.Instance.FindPool(poolType);
        }

        private void OnEnable()
        {
            StartCoroutine(DelayDestroy());
        }

        private void OnCollisionEnter(Collision collision)
        {
            dependentPool.Recycle(gameObject);
        }

        private void OnDisable()
        {
            StopAllCoroutines();
            rigidbody.velocity = Vector3.zero;
        }

        private IEnumerator DelayDestroy()
        {
            yield return new WaitForSeconds(destroyDelay);
            dependentPool.Recycle(gameObject);
        }
        #endregion

        #region Public Method
        public void AddForce(Vector3 force)
        {
            rigidbody.AddForce(force);
        }
        #endregion
    }
}