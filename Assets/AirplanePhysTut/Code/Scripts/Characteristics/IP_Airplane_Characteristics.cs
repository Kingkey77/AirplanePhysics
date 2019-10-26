using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace IndiePixel
{
    public class IP_Airplane_Characteristics : MonoBehaviour
    {
        #region Variables
        public float forwardSpeed;
        public float mph;
        private Rigidbody rb;
        private float startDrag;
        private float startAngularDrag;

        [Header("Lift Properties")]
        public float maxLiftPower = 800f;

        #endregion

        #region constants
        private float mpsToMph = 2.23694f;
        #endregion

        #region Built In Methods

        #endregion

        #region Custom Methods
        public void InitCharacteristics(Rigidbody curRB)
        {
            rb = curRB;
            startDrag = rb.drag;
            startAngularDrag = rb.angularDrag;


        }

        public void UpdateCharacteristics()
        {
            //Handle the flight model
            if (rb)
            {
                CalculateForwardSpeed();
                CalculateLift();
                CalculateDrag();
            }
        }

        void CalculateForwardSpeed()
        {
            Vector3 localVelocity = transform.InverseTransformDirection(rb.velocity);
            forwardSpeed = localVelocity.z;
            mph = forwardSpeed * mpsToMph;

            Debug.DrawRay(transform.position, transform.position + localVelocity, Color.green);
        }

        void CalculateLift()
        {
            Vector3 liftDir = transform.up;
            float liftPower = forwardSpeed * maxLiftPower;
            Vector3 finalLiftForce = liftDir * liftPower;
            rb.AddForce(finalLiftForce);

        }

        void CalculateDrag()
        {

        }
        #endregion

    }
}
