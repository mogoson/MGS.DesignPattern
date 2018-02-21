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

namespace Developer.ObjectPool
{
    [AddComponentMenu("Developer/ObjectPool/Gun")]
    public class Gun : MonoBehaviour
    {
        #region Property and Field
        [SerializeField]
        private GameObjectPoolType bulletPoolType;
        public Transform muzzle;
        public float fireForce = 100;

        private GameObjectPool bulletPool;
        #endregion

        #region Private Method
        private void Start()
        {
            bulletPool = GameObjectPoolManager.Instance.FindPool(bulletPoolType);
        }

        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                var bulletObj = bulletPool.TakeNew(null, muzzle.position, muzzle.rotation);
                bulletObj.GetComponent<Bullet>().AddForce(muzzle.forward * fireForce);
            }
        }
        #endregion
    }
}