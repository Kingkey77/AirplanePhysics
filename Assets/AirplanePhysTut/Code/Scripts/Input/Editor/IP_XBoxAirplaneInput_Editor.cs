using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace IndiePixel
{
   [CustomEditor(typeof(IP_XBoxAirplane_Input))]
    public class IP_XBoxAirplaneInput_Editor : Editor
    {
        #region Variables
        private IP_Base_Airplane_Input targetInput;
        #endregion

        #region BuiltinMethods
        private void OnEnable()
        {
            targetInput = (IP_Base_Airplane_Input)target;
        }

        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            string debugInfo = "";
            debugInfo += "Pitch    = " + targetInput.Pitch + "\n";
            debugInfo += "Roll     = " + targetInput.Roll + "\n";
            debugInfo += "Yaw      = " + targetInput.Yaw + "\n";
            debugInfo += "Throttle = " + targetInput.Throttle + "\n";
            debugInfo += "Brake    = " + targetInput.Brake + "\n";
            debugInfo += "Flaps    = " + targetInput.Flaps + "\n";

            //custom Editor Code
            GUILayout.Space(20);
            EditorGUILayout.TextArea(debugInfo, GUILayout.Height(100));
            GUILayout.Space(20);

            Repaint();

        }
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }
        #endregion
    }
}
