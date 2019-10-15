using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace IndiePixel
{
    [RequireComponent(typeof(WheelCollider))]

    public class Ip_Airplane_Wheels : MonoBehaviour
    {

        #region Variables
        private WheelCollider wheelCol;

        #endregion

        #region Built In Methods
        // Start is called before the first frame update
        void Start()
        {
            wheelCol = GetComponent<WheelCollider>();
        }

        // Update is called once per frame
        void Update()
        {

        }
        #endregion

        #region Custom Methods
        public void InitWheel()
        {
            if (wheelCol)
            {
                wheelCol.motorTorque = 0.000000000001f;
            }
        }
        #endregion
    }
}
