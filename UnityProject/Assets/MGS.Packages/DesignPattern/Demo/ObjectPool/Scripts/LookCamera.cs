/*************************************************************************
 *  Copyright © 2018 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  LookCamera.cs
 *  Description  :  Simple look camera for demo.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  0.1.0
 *  Date         :  2/21/2018
 *  Description  :  Initial development version.
 *************************************************************************/

using UnityEngine;

namespace MGS.DesignPattern.Demo
{
    public class LookCamera : MonoBehaviour
    {
        #region Field and Property
        public float xSpeed = 120;
        public float ySpeed = 120;

        private float xAngle = 0;
        private float yAngle = 0;
        #endregion

        #region Private Method
        private void Start()
        {
            xAngle = transform.eulerAngles.x;
            yAngle = transform.eulerAngles.y;
        }

        private void Update()
        {
            xAngle += Input.GetAxis("Mouse Y") * xSpeed * Time.deltaTime;
            yAngle -= Input.GetAxis("Mouse X") * ySpeed * Time.deltaTime;

            xAngle = Mathf.Clamp(xAngle, -90, 90);
            transform.rotation = Quaternion.Euler(new Vector3(xAngle, yAngle));
        }
        #endregion
    }
}