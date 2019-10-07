using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace IndiePixel
{
    public class IP_Base_Airplane_Input : MonoBehaviour
    {
        #region variables 
        protected float pitch = 0f;
        protected float roll = 0f;
        protected float yaw = 0f;
        protected float throttle = 0f;

        protected int flaps = 1;
        protected float brake = 0f;
        public KeyCode brakeKey = KeyCode.Space;
        public int maxFlapIncrements = 2;

        #endregion

        #region Properties
        public float Pitch
        { get { return pitch; } }
        public float Yaw
        { get { return yaw; } }
        public float Roll
        { get { return roll; } }
        public float Throttle
        { get { return throttle; } }
        public int Flaps
        { get { return flaps; } }
        public float Brake
        { get { return brake; } }



        #endregion

        #region Builtin Methods
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            HandleInput();
        }
        #endregion

        #region Custom Methods
        protected virtual void HandleInput()
        {
            pitch = Input.GetAxis("Vertical");
            roll = Input.GetAxis("Horizontal");
            yaw = Input.GetAxis("Yaw");
            throttle = Input.GetAxis("Throttle");

            brake = Input.GetKey(brakeKey) ? 1f : 0f;
            flaps = Mathf.Clamp(flaps, 0, maxFlapIncrements);
            if (Input.GetKeyDown(KeyCode.F))
                flaps += 1;
            if (Input.GetKeyDown(KeyCode.G))
                flaps -= 1;

            
        }
        #endregion
    }
}
