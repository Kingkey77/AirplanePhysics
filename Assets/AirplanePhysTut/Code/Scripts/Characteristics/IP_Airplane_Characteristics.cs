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
        public float maxMPH = 110f;
        private float maxMPS;
        private float normalisedMPH;

        [Header("Lift Properties")]
        public float maxLiftPower = 800f;
        public AnimationCurve LiftCurve = AnimationCurve.EaseInOut(0f, 0f, 1f, 1f);

        [Header("Drag Properties")]
        public float dragFactor = 0.01f;

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

            //find maxMPS
            maxMPS = maxMPH / mpsToMph;


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
            forwardSpeed = Mathf.Clamp(forwardSpeed, 0, maxMPS);
            mph = forwardSpeed * mpsToMph;
            mph = Mathf.Clamp(mph, 0, maxMPH);

            normalisedMPH = Mathf.InverseLerp(0f, maxMPH, mph);
            Debug.Log(normalisedMPH);
            Debug.DrawRay(transform.position, transform.position + localVelocity, Color.green);
        }

        void CalculateLift()
        {
            Vector3 liftDir = transform.up;
            float liftPower = LiftCurve.Evaluate(normalisedMPH) * maxLiftPower;
            Vector3 finalLiftForce = liftDir * liftPower;
            rb.AddForce(finalLiftForce);

        }

        void CalculateDrag()
        {
            float speedDrag = forwardSpeed * dragFactor;
            float finalDrag = startDrag + speedDrag;
            rb.drag = finalDrag;

            rb.angularDrag = startAngularDrag * forwardSpeed;
        }
        #endregion

    }
}
