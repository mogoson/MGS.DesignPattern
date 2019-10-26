/*************************************************************************
 *  Copyright © 2018 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  Gun.cs
 *  Description  :  Define gun for demo.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  0.1.0
 *  Date         :  2/9/2018
 *  Description  :  Initial development version.
 *************************************************************************/

using UnityEngine;

namespace MGS.ObjectPool
{
    [AddComponentMenu("MGS/ObjectPool/Gun")]
    public class Gun : MonoBehaviour
    {
        #region Field and Property
        public Transform muzzle;
        public GameObject bulletPrefab;
        public float fireForce = 100;

        public const string BULLET_POOL = "BulletPool";
        private GameObjectPool pool;
        #endregion

        #region Private Method
        private void Start()
        {
            pool = GameObjectPoolManager.Instance.CreatePool(BULLET_POOL, bulletPrefab);
        }

        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                var bullet = pool.TakeNew(muzzle.position, muzzle.rotation).GetComponent<Bullet>();
                bullet.AddForce(muzzle.forward * fireForce);
            }
        }
        #endregion
    }
}