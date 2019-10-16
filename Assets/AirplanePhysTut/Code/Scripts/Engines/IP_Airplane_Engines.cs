using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace IndiePixel
{
    public class IP_Airplane_Engines : MonoBehaviour
    {
        #region Variables
        [Header("Engine Properties")]
        public float maxForce = 200f;
        public float maxRPM = 2550f;
        public AnimationCurve powerCurve = AnimationCurve.Linear(0f, 0f, 1f, 1f);

        [Header("Propellors")]
        public Ip_Airplane_Propellors propellor;

        #endregion

        #region Built In Methods
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }
        #endregion

        #region Custom Methods
        public Vector3 CalculateForce (float throttle)
        {
            //Debug.Log("CalculateForce");
            //return Vector3.zero;
            //caluclate Power
            float finalThrottle = Mathf.Clamp01(throttle);
            finalThrottle = powerCurve.Evaluate(finalThrottle);
            float finalPower = finalThrottle * maxForce;

            //Calculate RPM's
            float currentRPM = finalThrottle * maxRPM;
            if (propellor)
            {
                propellor.HandlePropellor(currentRPM);
            }

            //Create Force!!!
            Vector3 finalForce = transform.forward * finalPower;
            return finalForce;

        }
        #endregion

       
    }
}