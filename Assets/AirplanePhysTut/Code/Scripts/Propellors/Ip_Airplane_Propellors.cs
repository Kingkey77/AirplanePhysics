using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace IndiePixel
{
    public class Ip_Airplane_Propellors : MonoBehaviour
    {
        #region Variables
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
        public void HandlePropellor(float CurrentRPM)
        {
            //calculate Degrees per second (DPS)
            float dps = (CurrentRPM * 360f) / 60f * Time.deltaTime;
            transform.Rotate(Vector3.forward, dps);
        }
        #endregion
    }
}
