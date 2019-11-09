using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace IndiePixel
{

    [RequireComponent(typeof(IP_Airplane_Characteristics))]
    public class IP_Airplane_Controller : IP_Base_Rigidbody_Controller
    {
        #region Variables
        [Header ("Base Airplane Properties")]
        public IP_Base_Airplane_Input input;
        public Transform centerOfGravity;

        [Tooltip("The weight is in LBS")]
        public float airplaneWeight = 800f;
        public IP_Airplane_Characteristics characteristics;

        [Header("Engines")]
        public List<IP_Airplane_Engines> engines = new List<IP_Airplane_Engines>();

        [Header("Wheels")]
        public List<Ip_Airplane_Wheels> wheels = new List<Ip_Airplane_Wheels>();

        [Header("Control Surfaces")]
        public List<IP_Airplane_ControlSurface> controlSurfaces = new List<IP_Airplane_ControlSurface>();


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
                characteristics = GetComponent<IP_Airplane_Characteristics>();
                if (characteristics)
                {
                    characteristics.InitCharacteristics(rb, input);
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
                HandleCharacteristics();
                HandleControlSurfaces();
                HandleSteering();
                HandleBrakes();
                HandleAltitude();
                Debug.Log("HandlePhysics in Airplane Controller is being called");
            }
        }

        void HandleEngines()
        {
            if (engines != null)
            {
                if (engines.Count > 0)
                {
                    Debug.Log("In Airplane_Controller.Handle Engines: "+ input.StickyThrottle + " ST\n");
                    foreach (IP_Airplane_Engines engine in engines)
                    {
                        rb.AddForce(engine.CalculateForce(input.StickyThrottle));
                    }

                }
            }
        }

        void HandleCharacteristics()
        {
            if (characteristics)
            {
                characteristics.UpdateCharacteristics();
            }

        }

        void HandleControlSurfaces()
        {
            if (controlSurfaces.Count > 0)
            {
                foreach (IP_Airplane_ControlSurface controlSurface in controlSurfaces)
                {
                    controlSurface.HandleControlSurface(input);
                }
            }
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