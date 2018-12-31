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


    public class GetVRButtonDown : FsmStateAction
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
        }

        public override void OnUpdate()
        {
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

            // Touchpad axis
            touchpadAxis.Value = OVRInput.Get(OVRInput.Axis2D.PrimaryTouchpad);

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

        }

        public override string ErrorCheck()
        {
            if (FsmEvent.IsNullOrEmpty(triggerButtonPressed) &&
                FsmEvent.IsNullOrEmpty(triggerButtonReleased) &&
                FsmEvent.IsNullOrEmpty(triggerButtonHeld) &&
                FsmEvent.IsNullOrEmpty(backButton) &&
                FsmEvent.IsNullOrEmpty(touchpadButtonPressed) &&
                FsmEvent.IsNullOrEmpty(touchpadButtonReleased) &&
                FsmEvent.IsNullOrEmpty(touchpadButtonHeld) &&
                FsmEvent.IsNullOrEmpty(touchpadPressedUp) &&
                FsmEvent.IsNullOrEmpty(touchpadPressedDown) &&
                FsmEvent.IsNullOrEmpty(touchpadPressedLeft) &&
                FsmEvent.IsNullOrEmpty(touchpadPressedRight) &&
                FsmEvent.IsNullOrEmpty(touchpadSwipeUp) &&
                FsmEvent.IsNullOrEmpty(touchpadSwipeDown) &&
                FsmEvent.IsNullOrEmpty(touchpadSwipeLeft) &&
                FsmEvent.IsNullOrEmpty(touchpadSwipeRight))
                return "Action sends no events!";
            return "";
        }
    }
}
