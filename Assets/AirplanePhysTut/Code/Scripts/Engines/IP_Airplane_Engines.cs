using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace IndiePixel
{



    public class IP_Airplane_Engines : MonoBehaviour
    {
        #region Variables
        public float maxForce = 200f;
        public float maxRPM = 2550f;
        #endregion

        #region Built In Methods
        #endregion

        #region Custom Methods
        public Vector3 CalculateForce (float throttle)
        {
            //Debug.Log("CalculateForce");
            //return Vector3.zero;
            float finalThrottle = Mathf.Clamp01(throttle);
            float finalPower = finalThrottle * maxForce;
            Vector3 finalForce = transform.forward * finalPower;
            return finalForce;

        }
        #endregion

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}