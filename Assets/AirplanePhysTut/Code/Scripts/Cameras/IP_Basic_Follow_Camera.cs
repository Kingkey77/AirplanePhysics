using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace IndiePixel
{


    public class IP_Basic_Follow_Camera : MonoBehaviour
    {
        #region Variables
        [Header("Basic Follow Camera Properties")]
        public Transform target;
        public float distance = 5f;
        public float height = 2f;
        public float smoothSpeed = 0.5f;
        private Vector3 smoothVelocity;
        protected float origHeight;

        #endregion

        #region Built in Methods

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void FixedUpdate()
        {
            if (target)
            {
                HandleCamera();
            }
        }
        #endregion

        #region Custom Method
        protected virtual void HandleCamera()
        {
            //follow target
            Vector3 wantedPosition = target.position + (-target.forward * distance) + (Vector3.up * height);
            Debug.DrawLine(target.position, wantedPosition, Color.blue);
            transform.position =Vector3.SmoothDamp(transform.position, wantedPosition, ref smoothVelocity, smoothSpeed);
            transform.LookAt(target);

        }

        #endregion

    }
}