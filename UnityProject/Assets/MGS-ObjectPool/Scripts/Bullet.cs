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

namespace MGS.ObjectPool
{
    [AddComponentMenu("MGS/ObjectPool/Bullet")]
    [RequireComponent(typeof(Rigidbody))]
    public class Bullet : MonoBehaviour
    {
        #region Field and Property
        public string relatePool = "BulletPool";
        public float destroyDelay = 3;

        private new Rigidbody rigidbody;
        private GameObjectPool pool;
        #endregion

        #region Private Method
        private void Awake()
        {
            rigidbody = GetComponent<Rigidbody>();
            pool = GameObjectPoolManager.Instance.FindPool(relatePool);
        }

        private void OnEnable()
        {
            StartCoroutine(DelayDestroy());
        }

        private void OnCollisionEnter(Collision collision)
        {
            pool.Recycle(gameObject);
        }

        private void OnDisable()
        {
            StopAllCoroutines();
            rigidbody.velocity = Vector3.zero;
        }

        private IEnumerator DelayDestroy()
        {
            yield return new WaitForSeconds(destroyDelay);
            pool.Recycle(gameObject);
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