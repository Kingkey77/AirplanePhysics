using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace IndiePixel
{
    
    public class IP_XBoxAirplane_Input : IP_Base_Airplane_Input
    {
        #region Variables
        
        #endregion

        #region Custom Methods
        protected override void HandleInput()
        {
            pitch = Input.GetAxis("Vertical");
            roll = Input.GetAxis("Horizontal");
            yaw = Input.GetAxis("X_RH_Stick");
            throttle = Input.GetAxis("X_RV_Stick");

            brake = Input.GetAxis("Fire1");
            
            if (Input.GetButtonDown("X_R_Bumper"))
                flaps += 1;
            if (Input.GetButtonDown("X_L_Bumper"))
                flaps -= 1;

            flaps = Mathf.Clamp(flaps, 0, maxFlapIncrements);
        }

        void StickyThrottleControl()
        {
            stickyThrottle = stickyThrottle + (throttle * throttleSpeed * Time.deltaTime);
            stickyThrottle = Mathf.Clamp01(stickyThrottle);
            Debug.Log(stickyThrottle);
        }
        #endregion
    }

}
