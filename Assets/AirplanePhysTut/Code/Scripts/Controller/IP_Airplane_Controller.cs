using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace IndiePixel
{


    public class IP_Airplane_Controller : IP_Base_Rigidbody_Controller
    {
        #region Variables
        [Header ("Base Airplane Properties")]
        public IP_Base_Airplane_Input input;
        public Transform centerOfGravity;

        [Tooltip("The weight is in LBS")]
        public float airplaneWeight = 800f;

        [Header("Engines")]
        public List<IP_Airplane_Engines> engines = new List<IP_Airplane_Engines>();

        [Header("Wheels")]
        public List<Ip_Airplane_Wheels> wheels = new List<Ip_Airplane_Wheels>();

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

            if (wheels != null)
            {
                if (wheels.Count > 0 )
                {
                    foreach (Ip_Airplane_Wheels wheel in wheels)
                    {
                        wheel.InitWheel();
                    }
                }
            }
            
        }
        #endregion

        #region CustomMethods
        protected override void HandlePhysics()
        {
            if (input)
            {
                HandleEngines();
                HandleAerodynamics();
                HandleSteering();
                HandleBrakes();
                HandleAltitude();
            }
        }

        void HandleEngines()
        {
            if (engines != null)
            {
                if (engines.Count > 0)
                {
                    foreach (IP_Airplane_Engines engine in engines)
                    {
                        rb.AddForce(engine.CalculateForce(-input.Throttle));
                    }

                }
            }
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