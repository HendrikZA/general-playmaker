// Custom Action by HendrikB
// You can find me on Playmaker forums for suggestions, bugs, fixes or just to say hello :)
// Script is based on OVRInput documentation from Oculus website
// You need the Oculus Utilities for Unity package
// Then find the OVRManager script that comes with Oculus Utilities package and add it to any gameobject in your scene.

using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{

    // Remember to add OVRManager script anywhere in the scene before OVRInput will work.
    [ActionCategory(ActionCategory.Input)]
    [Tooltip("Checks if the Oculus Go, or Gear VR, Dpad button has been pressed in a specific direction.")]


    public class OculusGoDpadDirection : FsmStateAction
    {
        // Dpad axis - hidden as it is used only in the background for this action.
        [HideInInspector]
        public FsmVector2 DpadAxis;

        // Dpad 4-way Pressed Direction
        [ActionSection("Dpad Pressed Direction")]
        [Tooltip("Checks if Dpad is pressed in the upward direction.")]
        public FsmEvent dpadPressedUp;
        [Tooltip("Dpad upward press sensitivity. How far should the button be pressed to the top of the Dpad before it triggers as being pressed upward? Defaults to 0.5, which means about 50% upwards from centre. This feels just right, but you can set it less or more depending on your needs.")]
        public FsmFloat upSensitivity = 0.5f;

        [Tooltip("Checks if Dpad is pressed in the downward direction.")]
        public FsmEvent dpadPressedDown;
        [Tooltip("Dpad downward press sensitivity. How far should the button be pressed to the bottom of the Dpad before it triggers as being pressed downward? Defaults to 0.5, which means about 50% downwards from centre. This feels just right, but you can set it less or more depending on your needs.")]
        public FsmFloat downSensitivity = -0.5f;

        [Tooltip("Checks if Dpad is pressed in the left direction.")]
        public FsmEvent dpadPressedLeft;
        [Tooltip("Dpad left press sensitivity. How far should the button be pressed to the left of the Dpad before it triggers as being pressed left? Defaults to 0.5, which means about 50% left from centre. This feels just right, but you can set it less or more depending on your needs.")]
        public FsmFloat leftSensitivity = -0.5f;

        [Tooltip("Checks if Dpad is pressed in the right direction.")]
        public FsmEvent dpadPressedRight;
        [Tooltip("Dpad right press sensitivity. How far should the button be pressed to the right of the Dpad before it triggers as being pressed right? Defaults to 0.5, which means about 50% right from centre. This feels just right, but you can set it less or more depending on your needs.")]
        public FsmFloat rightSensitivity = 0.5f;

        // Dpad Diagonal Pressed Direction
        [ActionSection("Dpad Pressed Diagonally")]
        [Tooltip("Checks if Dpad is pressed in the upper-left direction.")]
        public FsmEvent dpadPressedUpperLeft;
        [Tooltip("Sensitivity for X. Ranges from 0 to -1. It represents the distance from the centre of the Dpad to the left. -0.3 should work ok, but you can set this for less or more sensitivity.")]
        public FsmFloat upperLeftSensitivityX = -0.3f;
        [Tooltip("Sensitivity for Y. Ranges from 0 to 1. It represents the distance from the centre of the Dpad to the top. 0.3 should work ok, but you can set this for less or more sensitivity.")]
        public FsmFloat upperLeftSensitivityY = 0.3f;

        [Tooltip("Checks if Dpad is pressed in the upper-right direction.")]
        public FsmEvent dpadPressedUpperRight;
        [Tooltip("Sensitivity for X. Ranges from 0 to 1. It represents the distance from the centre of the Dpad to the right. 0.3 should work ok, but you can set this for less or more sensitivity.")]
        public FsmFloat upperRightSensitivityX = 0.3f;
        [Tooltip("Sensitivity for Y. Ranges from 0 to 1. It represents the distance from the centre of the Dpad to the top. 0.3 should work ok, but you can set this for less or more sensitivity.")]
        public FsmFloat upperRightSensitivityY = 0.3f;

        [Tooltip("Checks if Dpad is pressed in the lower-right direction.")]
        public FsmEvent dpadPressedLowerRight;
        [Tooltip("Sensitivity for X. Ranges from 0 to 1. It represents the distance from the centre of the Dpad to the right. 0.3 should work ok, but you can set this for less or more sensitivity.")]
        public FsmFloat lowerRightSensitivityX = 0.3f;
        [Tooltip("Sensitivity for Y. Ranges from 0 to -1. It represents the distance from the centre of the Dpad to the bottom. -0.3 should work ok, but you can set this for less or more sensitivity.")]
        public FsmFloat lowerRightSensitivityY = -0.3f;

        [Tooltip("Checks if Dpad is pressed in the lower-left direction.")]
        public FsmEvent dpadPressedLowerLeft;
        [Tooltip("Sensitivity for X. Ranges from 0 to -1. It represents the distance from the centre of the Dpad to the left. -0.3 should work ok, but you can set this for less or more sensitivity.")]
        public FsmFloat lowerLeftSensitivityX = -0.3f;
        [Tooltip("Sensitivity for Y. Ranges from 0 to -1. It represents the distance from the centre of the Dpad to the bottom. -0.3 should work ok, but you can set this for less or more sensitivity.")]
        public FsmFloat lowerLeftSensitivityY = -0.3f;

        // Resets all values to defaults
        public override void Reset()
        {
            dpadPressedUp = null;
            dpadPressedDown = null;
            dpadPressedLeft = null;
            dpadPressedRight = null;
            upSensitivity = 0.5f;
            downSensitivity = -0.5f;
            leftSensitivity = -0.5f;
            rightSensitivity = 0.5f;
            dpadPressedUpperLeft = null;
            dpadPressedUpperRight = null;
            dpadPressedLowerRight = null;
            dpadPressedLowerLeft = null;
            upperLeftSensitivityX = -0.3f;
            upperLeftSensitivityY = 0.3f;
            upperRightSensitivityX = 0.3f;
            upperRightSensitivityY = 0.3f;
            lowerRightSensitivityX = 0.3f;
            lowerRightSensitivityY = -0.3f;
            lowerLeftSensitivityX = -0.3f;
            lowerLeftSensitivityY = -0.3f;
        }

        public override void OnUpdate()
        {
            // Dpad pressed in a diagonal direction
            // Upper-right
            if ((DpadAxis.Value.x >= upperRightSensitivityX.Value) && (DpadAxis.Value.y >= upperRightSensitivityY.Value) && (OVRInput.GetDown(OVRInput.Button.One)))
            {
                Fsm.Event(dpadPressedUpperRight);
            }
            // Lower-right
            if ((DpadAxis.Value.x >= lowerRightSensitivityX.Value) && (DpadAxis.Value.y <= lowerRightSensitivityY.Value) && (OVRInput.GetDown(OVRInput.Button.One)))
            {
                Fsm.Event(dpadPressedLowerRight);
            }
            // Lower-left
            if ((DpadAxis.Value.x <= lowerLeftSensitivityX.Value) && (DpadAxis.Value.y <= lowerLeftSensitivityY.Value) && (OVRInput.GetDown(OVRInput.Button.One)))
            {
                Fsm.Event(dpadPressedLowerLeft);
            }
            // Upper-left
            if ((DpadAxis.Value.x <= upperLeftSensitivityX.Value) && (DpadAxis.Value.y >= upperLeftSensitivityY.Value) && (OVRInput.GetDown(OVRInput.Button.One)))
            {
                Fsm.Event(dpadPressedUpperLeft);
            }

            // Dpad pressed in a specific direction
            if ((DpadAxis.Value.x > rightSensitivity.Value) && OVRInput.GetDown(OVRInput.Button.One))
            {
                Fsm.Event(dpadPressedRight);
            }
            if ((DpadAxis.Value.x < leftSensitivity.Value) && OVRInput.GetDown(OVRInput.Button.One))
            {
                Fsm.Event(dpadPressedLeft);
            }
            if ((DpadAxis.Value.y > upSensitivity.Value) && OVRInput.GetDown(OVRInput.Button.One))
            {
                Fsm.Event(dpadPressedUp);
            }
            if ((DpadAxis.Value.y < downSensitivity.Value) && OVRInput.GetDown(OVRInput.Button.One))
            {
                Fsm.Event(dpadPressedDown);
            }
        }
    }
}