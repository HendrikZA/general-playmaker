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
    [Tooltip("Checks if the Oculus Go, or Gear VR, Dpad button has been pressed or released.")]


    public class OculusGoDpadButton : FsmStateAction
    {
        // Events to send
        // Touchpad button pressed in centre. Can't be used with other directional presses.
        [ActionSection("Touchpad Button")]
        [Tooltip("Event to send if Touchpad button was pressed.")]
        public FsmEvent touchpadButtonPressed;
        [Tooltip("Event to send if Touchpad button was released.")]
        public FsmEvent touchpadButtonReleased;

        // Resets all values to defaults
        public override void Reset()
        {
            touchpadButtonPressed = null;
            touchpadButtonReleased = null;
        }

        public override void OnUpdate()
        {
            // Touchpad pressed
            if (OVRInput.GetDown(OVRInput.Button.One))
            {
                Fsm.Event(touchpadButtonPressed);
            }
            
            // Touchpad released
            if (OVRInput.GetUp(OVRInput.Button.One))
            {
                Fsm.Event(touchpadButtonReleased);
            }
        }
    }
}