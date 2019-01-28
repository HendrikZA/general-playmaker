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
    [Tooltip("Checks if the Oculus Go, or Gear VR, dpad has been swiped.")]


    public class OculusGoDpadSwipes : FsmStateAction
    {
        // Events to send
        // Dpad Swipes
        [ActionSection("Dpad Swipes")]
        [Tooltip("Event to send if Dpad was swiped up.")]
        public FsmEvent dpadSwipeUp;

        [Tooltip("Event to send if Dpad was swiped down.")]
        public FsmEvent dpadSwipeDown;

        [Tooltip("Event to send if Dpad was swiped left.")]
        public FsmEvent dpadSwipeLeft;

        [Tooltip("Event to send if Dpad was swiped right.")]
        public FsmEvent dpadSwipeRight;

        // Resets all values to defaults
        public override void Reset()
        {
            dpadSwipeUp = null;
            dpadSwipeDown = null;
            dpadSwipeLeft = null;
            dpadSwipeRight = null;
        }

        public override void OnUpdate()
        {
            // Touchpad Swipes
            if (OVRInput.GetDown(OVRInput.Button.DpadUp))
            {
                Fsm.Event(dpadSwipeUp);
            }
            if (OVRInput.GetDown(OVRInput.Button.DpadDown))
            {
                Fsm.Event(dpadSwipeDown);
            }
            if (OVRInput.GetDown(OVRInput.Button.DpadLeft))
            {
                Fsm.Event(dpadSwipeLeft);
            }
            if (OVRInput.GetDown(OVRInput.Button.DpadRight))
            {
                Fsm.Event(dpadSwipeRight);
            }
        }
    }
}