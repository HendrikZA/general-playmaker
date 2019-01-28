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
    [Tooltip("Checks if the Oculus Go, or Gear VR, controller buttons have been pressed or swiped. Add the OVRManager.cs script to any Gameobject in the scene. It can be found in the Oculus Utilities package.")]


    public class OculusGoButtonDown : FsmStateAction
    {
        // Events to send
        // Trigger button pressed
        [ActionSection("Trigger Button")]
        [Tooltip("Event to send if Trigger button was pressed.")]
        public FsmEvent triggerButtonPressed;
        [Tooltip("Event to send if Trigger button was released.")]
        public FsmEvent triggerButtonReleased;
        [Tooltip("Event to send if Trigger button is being held down. This can be used to check for long press.")]
        public FsmEvent triggerButtonHeld;

        // Back button pressed
        [ActionSection("Back Button")]
        [Tooltip("Event to send if Back button was pressed.")]
        public FsmEvent backButton;

        // Touchpad button pressed in centre. Can't be used with other directional presses.
        [ActionSection("Touchpad Button")]
        [Tooltip("Event to send if Touchpad button was pressed.")]
        public FsmEvent touchpadButtonPressed;
        [Tooltip("Event to send if Touchpad button was released.")]
        public FsmEvent touchpadButtonReleased;
        [Tooltip("Event to send if Touchpad button is being held down. This can be used to check for long press.")]
        public FsmEvent touchpadButtonHeld;

        // Touchpad Swipes
        [ActionSection("Touchpad Swipes")]
        [Tooltip("Event to send if Touchpad was swiped up.")]
        public FsmEvent touchpadSwipeUp;

        [Tooltip("Event to send if Touchpad was swiped down.")]
        public FsmEvent touchpadSwipeDown;

        [Tooltip("Event to send if Touchpad was swiped left.")]
        public FsmEvent touchpadSwipeLeft;

        [Tooltip("Event to send if Touchpad was swiped right.")]
        public FsmEvent touchpadSwipeRight;

        // Touchpad axis
        [ActionSection("Touchpad Axis")]
        [Tooltip("Checks finger position on the touchpad. Can be used for FPS movement and all kinds of useful things.")]
        [UIHint(UIHint.Variable)]
        public FsmVector2 touchpadAxis;

        // Touchpad Pressed Direction
        [ActionSection("Touchpad Pressed Direction")]
        [Tooltip("Checks if Touchpad is pressed in the upward direction.")]
        public FsmEvent touchpadPressedUp;
        [Tooltip("Touchpad upward press sensitivity. How far should the button be pressed to the top of the touchpad before it triggers as being pressed upward? Defaults to 0.5, which means about 50% upwards from centre. This feels just right, but you can set it less or more depending on your needs.")]
        public FsmFloat upSensitivity = 0.5f;

        [Tooltip("Checks if Touchpad is pressed in the downward direction.")]
        public FsmEvent touchpadPressedDown;
        [Tooltip("Touchpad downward press sensitivity. How far should the button be pressed to the bottom of the touchpad before it triggers as being pressed downward? Defaults to 0.5, which means about 50% downwards from centre. This feels just right, but you can set it less or more depending on your needs.")]
        public FsmFloat downSensitivity = -0.5f;

        [Tooltip("Checks if Touchpad is pressed in the left direction.")]
        public FsmEvent touchpadPressedLeft;
        [Tooltip("Touchpad left press sensitivity. How far should the button be pressed to the left of the touchpad before it triggers as being pressed left? Defaults to 0.5, which means about 50% left from centre. This feels just right, but you can set it less or more depending on your needs.")]
        public FsmFloat leftSensitivity = -0.5f;

        [Tooltip("Checks if Touchpad is pressed in the right direction.")]
        public FsmEvent touchpadPressedRight;
        [Tooltip("Touchpad right press sensitivity. How far should the button be pressed to the right of the touchpad before it triggers as being pressed right? Defaults to 0.5, which means about 50% right from centre. This feels just right, but you can set it less or more depending on your needs.")]
        public FsmFloat rightSensitivity = 0.5f;

        // Touchpad Diagonal Pressed Direction
        [ActionSection("Touchpad Pressed Diagonally")]
        [Tooltip("Checks if Touchpad is pressed in the upper-left direction.")]
        public FsmEvent touchpadPressedUpperLeft;
        [Tooltip("Sensitivity for X. Ranges from 0 to -1. It represents the distance from the centre of the touchpad to the left. -0.3 should work ok, but you can set this for less or more sensitivity.")]
        public FsmFloat upperLeftSensitivityX = -0.3f;
        [Tooltip("Sensitivity for Y. Ranges from 0 to 1. It represents the distance from the centre of the touchpad to the top. 0.3 should work ok, but you can set this for less or more sensitivity.")]
        public FsmFloat upperLeftSensitivityY = 0.3f;

        [Tooltip("Checks if Touchpad is pressed in the upper-right direction.")]
        public FsmEvent touchpadPressedUpperRight;
        [Tooltip("Sensitivity for X. Ranges from 0 to 1. It represents the distance from the centre of the touchpad to the right. 0.3 should work ok, but you can set this for less or more sensitivity.")]
        public FsmFloat upperRightSensitivityX = 0.3f;
        [Tooltip("Sensitivity for Y. Ranges from 0 to 1. It represents the distance from the centre of the touchpad to the top. 0.3 should work ok, but you can set this for less or more sensitivity.")]
        public FsmFloat upperRightSensitivityY = 0.3f;

        [Tooltip("Checks if Touchpad is pressed in the lower-right direction.")]
        public FsmEvent touchpadPressedLowerRight;
        [Tooltip("Sensitivity for X. Ranges from 0 to 1. It represents the distance from the centre of the touchpad to the right. 0.3 should work ok, but you can set this for less or more sensitivity.")]
        public FsmFloat lowerRightSensitivityX = 0.3f;
        [Tooltip("Sensitivity for Y. Ranges from 0 to -1. It represents the distance from the centre of the touchpad to the bottom. -0.3 should work ok, but you can set this for less or more sensitivity.")]
        public FsmFloat lowerRightSensitivityY = -0.3f;

        [Tooltip("Checks if Touchpad is pressed in the lower-left direction.")]
        public FsmEvent touchpadPressedLowerLeft;
        [Tooltip("Sensitivity for X. Ranges from 0 to -1. It represents the distance from the centre of the touchpad to the left. -0.3 should work ok, but you can set this for less or more sensitivity.")]
        public FsmFloat lowerLeftSensitivityX = -0.3f;
        [Tooltip("Sensitivity for Y. Ranges from 0 to -1. It represents the distance from the centre of the touchpad to the bottom. -0.3 should work ok, but you can set this for less or more sensitivity.")]
        public FsmFloat lowerLeftSensitivityY = -0.3f;

        // Capacitive Surface Touched
        [ActionSection("Capacitive Surface")]
        [Tooltip("Checks if capacitive surface of touchpad is being touched towards the top.")]
        public FsmEvent capacitiveTouchedUp;
        [Tooltip("Capacitive surface upward press sensitivity. How far should the surface be touched to the top of the capacitive surface before it triggers as being pressed up? Defaults to 0.5, which means about 50% up from centre. This feels just right, but you can set it less or more depending on your needs.")]
        public FsmFloat capacitiveUpSensitivity = 0.5f;

        [Tooltip("Checks if capacitive surface of touchpad is being touched towards the bottom.")]
        public FsmEvent capacitiveTouchedDown;
        [Tooltip("Capacitive surface downward press sensitivity. How far should the surface be touched to the bottom of the capacitive surface before it triggers as being pressed down? Defaults to 0.5, which means about 50% down from centre. This feels just right, but you can set it less or more depending on your needs.")]
        public FsmFloat capacitiveDownSensitivity = -0.5f;

        [Tooltip("Checks if capacitive surface of touchpad is being touched towards the left.")]
        public FsmEvent capacitiveTouchedLeft;
        [Tooltip("Capacitive surface left press sensitivity. How far should the surface be touched to the left of the capacitive surface before it triggers as being pressed left? Defaults to 0.5, which means about 50% left from centre. This feels just right, but you can set it less or more depending on your needs.")]
        public FsmFloat capacitiveLeftSensitivity = -0.5f;

        [Tooltip("Checks if capacitive surface of touchpad is being touched towards the right.")]
        public FsmEvent capacitiveTouchedRight;
        [Tooltip("Capacitive surface right press sensitivity. How far should the surface be touched to the right of the capacitive surface before it triggers as being pressed right? Defaults to 0.5, which means about 50% right from centre. This feels just right, but you can set it less or more depending on your needs.")]
        public FsmFloat capacitiveRightSensitivity = 0.5f;

        // Resets all values to defaults
        public override void Reset()
        {
            triggerButtonPressed = null;
            triggerButtonReleased = null;
            triggerButtonHeld = null;
            backButton = null;
            touchpadButtonPressed = null;
            touchpadButtonReleased = null;
            touchpadButtonHeld = null;
            touchpadSwipeUp = null;
            touchpadSwipeDown = null;
            touchpadSwipeLeft = null;
            touchpadSwipeRight = null;
            touchpadPressedUp = null;
            touchpadPressedDown = null;
            touchpadPressedLeft = null;
            touchpadPressedRight = null;
            upSensitivity = 0.5f;
            downSensitivity = -0.5f;
            leftSensitivity = -0.5f;
            rightSensitivity = 0.5f;
            touchpadPressedUpperLeft = null;
            touchpadPressedUpperRight = null;
            touchpadPressedLowerRight = null;
            touchpadPressedLowerLeft = null;
            upperLeftSensitivityX = -0.3f;
            upperLeftSensitivityY = 0.3f;
            upperRightSensitivityX = 0.3f;
            upperRightSensitivityY = 0.3f;
            lowerRightSensitivityX = 0.3f;
            lowerRightSensitivityY = -0.3f;
            lowerLeftSensitivityX = -0.3f;
            lowerLeftSensitivityY = -0.3f;
            capacitiveTouchedUp = null;
            capacitiveTouchedDown = null;
            capacitiveTouchedLeft = null;
            capacitiveTouchedRight = null;
            capacitiveUpSensitivity = 0.5f;
            capacitiveDownSensitivity = -0.5f;
            capacitiveLeftSensitivity = -0.5f;
            capacitiveRightSensitivity = 0.5f;
        }

        public override void OnUpdate()
        {
            // Touchpad axis
            touchpadAxis.Value = OVRInput.Get(OVRInput.Axis2D.PrimaryTouchpad);

            // Trigger button pressed
            if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger))
            {
                Fsm.Event(triggerButtonPressed);
            }
            if (OVRInput.GetUp(OVRInput.Button.PrimaryIndexTrigger))
            {
                Fsm.Event(triggerButtonReleased);
            }
            if (OVRInput.Get(OVRInput.Button.PrimaryIndexTrigger))
            {
                Fsm.Event(triggerButtonHeld);
            }

            // Back button pressed
            if (OVRInput.GetDown(OVRInput.Button.Back))
            {
                Fsm.Event(backButton);
            }

            // Touchpad pressed
            if (OVRInput.GetDown(OVRInput.Button.One))
            {
                Fsm.Event(touchpadButtonPressed);
            }
            if (OVRInput.GetUp(OVRInput.Button.One))
            {
                Fsm.Event(touchpadButtonReleased);
            }
            if (OVRInput.Get(OVRInput.Button.One))
            {
                Fsm.Event(touchpadButtonHeld);
            }

            // Touchpad Swipes
            if (OVRInput.GetDown(OVRInput.Button.DpadUp))
            {
                Fsm.Event(touchpadSwipeUp);
            }
            if (OVRInput.GetDown(OVRInput.Button.DpadDown))
            {
                Fsm.Event(touchpadSwipeDown);
            }
            if (OVRInput.GetDown(OVRInput.Button.DpadLeft))
            {
                Fsm.Event(touchpadSwipeLeft);
            }
            if (OVRInput.GetDown(OVRInput.Button.DpadRight))
            {
                Fsm.Event(touchpadSwipeRight);
            }

            // Touchpad pressed in a diagonal direction
            // Upper-right
            if ((touchpadAxis.Value.x >= upperRightSensitivityX.Value) && (touchpadAxis.Value.y >= upperRightSensitivityY.Value) && (OVRInput.GetDown(OVRInput.Button.One)))
            {
                Fsm.Event(touchpadPressedUpperRight);
            }
            // Lower-right
            if ((touchpadAxis.Value.x >= lowerRightSensitivityX.Value) && (touchpadAxis.Value.y <= lowerRightSensitivityY.Value) && (OVRInput.GetDown(OVRInput.Button.One)))
            {
                Fsm.Event(touchpadPressedLowerRight);
            }
            // Lower-left
            if ((touchpadAxis.Value.x <= lowerLeftSensitivityX.Value) && (touchpadAxis.Value.y <= lowerLeftSensitivityY.Value) && (OVRInput.GetDown(OVRInput.Button.One)))
            {
                Fsm.Event(touchpadPressedLowerLeft);
            }
            // Upper-left
            if ((touchpadAxis.Value.x <= upperLeftSensitivityX.Value) && (touchpadAxis.Value.y >= upperLeftSensitivityY.Value) && (OVRInput.GetDown(OVRInput.Button.One)))
            {
                Fsm.Event(touchpadPressedUpperLeft);
            }

            // Touchpad pressed in a specific direction
            if ((touchpadAxis.Value.x > rightSensitivity.Value) && OVRInput.GetDown(OVRInput.Button.One))
            {
                Fsm.Event(touchpadPressedRight);
            }
            if ((touchpadAxis.Value.x < leftSensitivity.Value) && OVRInput.GetDown(OVRInput.Button.One))
            {
                Fsm.Event(touchpadPressedLeft);
            }
            if ((touchpadAxis.Value.y > upSensitivity.Value) && OVRInput.GetDown(OVRInput.Button.One))
            {
                Fsm.Event(touchpadPressedUp);
            }
            if ((touchpadAxis.Value.y < downSensitivity.Value) && OVRInput.GetDown(OVRInput.Button.One))
            {
                Fsm.Event(touchpadPressedDown);
            }

            // Capacitive surface touched in a specific direction
            if (touchpadAxis.Value.x > rightSensitivity.Value)
            {
                Fsm.Event(capacitiveTouchedRight);
            }
            if (touchpadAxis.Value.x < leftSensitivity.Value)
            {
                Fsm.Event(capacitiveTouchedLeft);
            }
            if (touchpadAxis.Value.y > upSensitivity.Value)
            {
                Fsm.Event(capacitiveTouchedUp);
            }
            if (touchpadAxis.Value.y < downSensitivity.Value)
            {
                Fsm.Event(capacitiveTouchedDown);
            }
        }
    }
}
