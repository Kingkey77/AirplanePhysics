using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace IndiePixel
{
    public class IP_XBoxAirplane_Input : IP_Base_Airplane_Input
    {
        protected override void HandleInput()
        {
            pitch = Input.GetAxis("Vertical");
            roll = Input.GetAxis("Horizontal");
            yaw = Input.GetAxis("Yaw");
            throttle = Input.GetAxis("Throttle");

            brake = Input.GetAxis("Fire1");
            flaps = Mathf.Clamp(flaps, 0, maxFlapIncrements);
            if (Input.GetKeyDown(KeyCode.F))
                flaps += 1;
            if (Input.GetKeyDown(KeyCode.G))
                flaps -= 1;
        }
    }

}
