using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace IndiePixel
{
    [RequireComponent(typeof(Rigidbody))]

    public class IP_Rigidbody_Controller : MonoBehaviour
    {
        #region variables
        private Rigidbody rb;
        private AudioSource aSource;


        #endregion

        #region Builtin Methods
        // Start is called before the first frame update
        void Start()
        {
            rb = GetComponent<Rigidbody>();
            aSource = GetComponent<AudioSource>();
            if (aSource)
                aSource.playOnAwake = false;
        }

        // Update is called once per frame
        void FixedUpdate()
        {
            if (rb)
                HandlePhysics();
                
        }
        #endregion

        #region Custom Methods

        protected virtual void HandlePhysics()
        {

        }
        #endregion 
    }
}
