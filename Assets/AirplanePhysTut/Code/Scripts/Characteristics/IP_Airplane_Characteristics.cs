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
        private IP_Base_Airplane_Input input;
        private float startDrag;
        private float startAngularDrag;
        public float maxMPH = 110f;
        private float maxMPS;
        private float normalisedMPH;
        private float angleOfAttack;
        private float pitchAngle;
        private float rollAngle;
        private float yawAngle;
        [Header("Characteristic Properties")]
        public float rbLerpSpeed = 0.01f;

        [Header("Lift Properties")]
        public float maxLiftPower = 800f;
        public AnimationCurve LiftCurve = AnimationCurve.EaseInOut(0f, 0f, 1f, 1f);

        [Header("Drag Properties")]
        public float dragFactor = 0.01f;

        [Header("Control Properties")]
        public float pitchSpeed = 1000f;
        public float rollSpeed = 1000f;
        public float yawSpeed = 1000f;

        #endregion

        #region constants
        private float mpsToMph = 2.23694f;
        #endregion

        #region Built In Methods

        #endregion

        #region Custom Methods
        public void InitCharacteristics(Rigidbody curRB, IP_Base_Airplane_Input currInput)
        {
            input = currInput;
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
                handlePitch();
                handleRoll();
                handleYaw();
                handleBanking();

                HandleRigidbodyTransform();
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
            //Get Angle of Attack
            angleOfAttack = Vector3.Dot(rb.velocity, transform.forward);
            angleOfAttack *= angleOfAttack;
            Debug.Log(angleOfAttack);

            //calculateLift
            Vector3 liftDir = transform.up;
            float liftPower = LiftCurve.Evaluate(normalisedMPH) * maxLiftPower;
            Vector3 finalLiftForce = liftDir * liftPower * angleOfAttack;
            rb.AddForce(finalLiftForce);

           

        }

        void CalculateDrag()
        {
            float speedDrag = forwardSpeed * dragFactor;
            float finalDrag = startDrag + speedDrag;
            rb.drag = finalDrag;

            rb.angularDrag = startAngularDrag * forwardSpeed;
        }

        void HandleRigidbodyTransform()
        {
            if (rb.velocity.magnitude > 1f)
            {
                Vector3 updatedVelocity = Vector3.Lerp(rb.velocity, transform.forward * forwardSpeed, forwardSpeed * angleOfAttack * Time.deltaTime * rbLerpSpeed);
                rb.velocity = updatedVelocity;

                Quaternion updatedRotation = Quaternion.Slerp(rb.rotation, Quaternion.LookRotation(rb.velocity.normalized, transform.up), Time.deltaTime *rbLerpSpeed);
                rb.MoveRotation(updatedRotation);
            }
        }

        void handlePitch()
        {
            Vector3 flatForward = transform.forward;
            flatForward.y = 0f;

            pitchAngle = Vector3.Angle(transform.forward, flatForward);
            flatForward = flatForward.normalized;

            Vector3 pitchTorque = input.Pitch * pitchSpeed * transform.right;

            rb.AddTorque(pitchTorque);

        }

        void handleRoll()
        {
            Vector3 flatRight = transform.right;
            flatRight.y = 0f;
            rollAngle = Vector3.SignedAngle(transform.right, flatRight, transform.forward);
            flatRight = flatRight.normalized;

            Vector3 rollTorque = input.Roll * rollSpeed * transform.forward;
            rb.AddTorque(rollTorque);

        }

        void handleYaw()
        {
            Vector3 straightYaw = transform.up;
            straightYaw.y = 0f;
            rollAngle = Vector3.Angle(transform.up, straightYaw);
            straightYaw = straightYaw.normalized;

            Vector3 yawTorque = input.Yaw * yawSpeed * transform.up;
            rb.AddTorque(yawTorque);

        }

        void handleBanking()
        {
            float bankSide = Mathf.InverseLerp(-90f, 90f, rollAngle);
            float bankAmount = Mathf.Lerp(-1f, 1f, bankSide);

            Vector3 bankTorque = bankAmount * rollSpeed * transform.up;
            rb.AddTorque(bankTorque);

        }
        #endregion

    }
}
