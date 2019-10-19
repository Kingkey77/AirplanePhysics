using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace IndiePixel
{
    public class Ip_Airplane_Propellors : MonoBehaviour
    {
        #region Variables
        [Header("Propeller Properties")]
        public float minQuadRPM = 300f;
        public float minTextureSwap = 600f;
        public GameObject mainProp;
        public GameObject blurredProp;

        [Header("Material Properties")]
        public Material blurredPropMat;
        public Texture2D blurLevel01;
        public Texture2D blurLevel02;
        #endregion

        #region Built In Methods
        // Start is called before the first frame update
        void Start()
        {
            if (mainProp && blurredProp)
            {
                HandleSwapping(0f);
            }
        }

        // Update is called once per frame
        void Update()
        {

        }
        #endregion
        #region Custom Methods
        public void HandlePropellor(float CurrentRPM)
        {
            //calculate Degrees per second (DPS)
            float dps = (CurrentRPM * 360f) / 60f * Time.deltaTime;
            transform.Rotate(Vector3.forward, dps);
            if (mainProp && blurredProp)
            {
                HandleSwapping(CurrentRPM);
            }
        }

        public void HandleSwapping(float currentRPM)
        {
            if (currentRPM > minQuadRPM)
            {
                blurredProp.gameObject.SetActive(true);
                mainProp.gameObject.SetActive(false);
                if (blurredPropMat && blurLevel01 && blurLevel02)
                {
                    if (currentRPM > minTextureSwap)
                    {
                        blurredPropMat.SetTexture("_MainTex", blurLevel02);
                    }
                    else
                    {
                        blurredPropMat.SetTexture("_MainTex", blurLevel01);
                    }

                }
            }
            else
            {
                blurredProp.gameObject.SetActive(false);
                mainProp.gameObject.SetActive(true);
            }
        }
        #endregion
    }
}
