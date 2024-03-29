﻿/*************************************************************************
 *  Copyright © 2021 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  Gun.cs
 *  Description  :  Define gun for demo.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  0.1.0
 *  Date         :  2/9/2021
 *  Description  :  Initial development version.
 *************************************************************************/

using UnityEngine;

namespace MGS.DesignPattern.Demo
{
    public class Gun : MonoBehaviour
    {
        #region Field and Property
        public Transform muzzle;
        public GameObject bulletPrefab;
        public float fireForce = 100;

        public const string POOL_NAME_BULLET = "POOL_BULLET";
        private GameObjectPool bulletPool;
        #endregion

        #region Private Method
        private void Start()
        {
            bulletPool = GameObjectPoolManager.Instance.CreatePool(POOL_NAME_BULLET, bulletPrefab);
        }

        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                var bullet = bulletPool.Take<Bullet>();
                bullet.transform.position = muzzle.position;
                bullet.transform.rotation = muzzle.rotation;
                bullet.AddForce(muzzle.forward * fireForce);
            }
        }
        #endregion
    }
}