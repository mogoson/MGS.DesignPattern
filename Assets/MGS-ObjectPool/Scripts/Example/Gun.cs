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

namespace Mogoson.ObjectPool
{
    public class Gun : MonoBehaviour
    {
        #region Field and Property
        [SerializeField]
        private string bulletPool = "BulletPool";
        public Transform muzzle;
        public float fireForce = 100;

        private GameObjectPool pool;
        #endregion

        #region Private Method
        private void Start()
        {
            pool = GameObjectPoolManager.Instance.FindPool(bulletPool);
        }

        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                pool.TakeNew(null, muzzle.position, muzzle.rotation).GetComponent<Bullet>().AddForce(muzzle.forward * fireForce);
            }
        }
        #endregion
    }
}