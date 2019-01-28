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
    [Tooltip("Checks if the Oculus Go, or Gear VR, trigger has been pressed or released.")]


    public class OculusGoTriggerButton : FsmStateAction
    {
        // Events to send
        // Trigger button pressed
        [ActionSection("Trigger Button")]
        [Tooltip("Event to send if Trigger button was pressed.")]
        public FsmEvent triggerButtonPressed;
        [Tooltip("Event to send if Trigger button was released.")]
        public FsmEvent triggerButtonReleased;

        // Resets all values to defaults
        public override void Reset()
        {
            triggerButtonPressed = null;
            triggerButtonReleased = null;
        }

        public override void OnUpdate()
        {
            // Trigger button pressed
            if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger))
            {
                Fsm.Event(triggerButtonPressed);
            }

            // Trigger button released
            if (OVRInput.GetUp(OVRInput.Button.PrimaryIndexTrigger))
            {
                Fsm.Event(triggerButtonReleased);
            }
        }
    }
}