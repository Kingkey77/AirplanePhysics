using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace IndiePixel
{


    public class IP_Airplane_Controller : IP_Base_Rigidbody_Controller
    {
        #region Variables
        [Header ("Base Airplane Properties")]
        public IP_XBoxAirplane_Input input;
        public Transform centerOfGravity;

        [Tooltip("The weight is in LBS")]
        public float airplaneWeight = 800f;
        #endregion

        #region Contants
        const float poundsToKilos = 0.453592f;
        #endregion

        #region BuiltingMethods
        public override void Start()
        {
            base.Start();

            float finalMass= airplaneWeight * poundsToKilos;
            if(rb)
            {
                rb.mass = finalMass;
                if (centerOfGravity)
                {
                    rb.centerOfMass = centerOfGravity.localPosition;
                }
            }
        }
        #endregion

        #region CustomMethods
        protected override void HandlePhysics()
        {
            HandleEngines();
            HandleAerodynamics();
            HandleSteering();
            HandleBrakes();
            HandleAltitude();

        }

        void HandleEngines()
        {

        }

        void HandleAerodynamics()
        {

        }

        void HandleSteering()
        {

        }

        void HandleBrakes()
        {

        }

        void HandleAltitude()
        {

        }

        #endregion 


    }
}