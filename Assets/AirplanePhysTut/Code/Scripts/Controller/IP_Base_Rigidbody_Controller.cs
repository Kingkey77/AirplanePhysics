using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace IndiePixel
{
    [RequireComponent(typeof(Rigidbody))]
    [RequireComponent(typeof(AudioSource))]

    public class IP_Base_Rigidbody_Controller : MonoBehaviour
    {
        #region variables
        public Rigidbody rb;
        public AudioSource aSource;


        #endregion

        #region Built in Methods
        // Start is called before the first frame update
        public virtual void Start()
        {
            rb = GetComponent<Rigidbody>();
            //Debug.Log("Base_RigidBody_Controller.rigidbody" + rb);
            aSource = GetComponent<AudioSource>();
            if (aSource)
                aSource.playOnAwake = false;
        }

        
        void FixedUpdate()
        {
            //Debug.Log("RigidBody : " + rb);
            if (rb)
            {
                HandlePhysics();
                //Debug.Log("HandlePhysics to be called in Base_Rigidbody_Controller.FixedUpdate");
            }
                
        }
        #endregion

        #region Custom Methods

        protected virtual void HandlePhysics()
        {
            //Debug.Log("HandlePhysics in BaseRigidBodyController.HandlePhysics is being called");
        }
        #endregion 
    }
}
