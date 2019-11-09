using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace IndiePixel
{

    public class IP_XBoxAirplane_Input : IP_Base_Airplane_Input
    {
        #region Variables
        //public float throttleSpeed = 0.1f;      //rate of change of throttle for stickythrottle
        //private float stickyThrottle;           
        //public float StickyThrottle
           //{get {return stickyThrottle;} }
        
        //IP_Base_Airplane_Input input;
        #endregion
        
        #region Custom Methods
        protected override void HandleInput()
        {
            pitch = Input.GetAxis("X_LV_Stick");
            roll = Input.GetAxis("X_LH_Stick");
            yaw = Input.GetAxis("X_RH_Stick");
            throttle = Input.GetAxis("X_RV_Stick");
            StickyThrottleControl();

            brake = Input.GetAxis("Fire1");
            
            if (Input.GetButtonDown("X_R_Bumper"))
                flaps += 1;
            if (Input.GetButtonDown("X_L_Bumper"))
                flaps -= 1;

            flaps = Mathf.Clamp(flaps, 0, maxFlapIncrements);
        }
        #endregion
    }

}
