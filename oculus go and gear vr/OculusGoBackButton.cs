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
    [Tooltip("Checks if the Oculus Go, or Gear VR, back button has been pressed.")]


    public class OculusGoBackButton : FsmStateAction
    {
        // Events to send
        // Back button pressed
        [ActionSection("Back Button")]
        [Tooltip("Event to send if Back button was pressed.")]
        public FsmEvent backButton;

        // Resets all values to defaults
        public override void Reset()
        {
            backButton = null;
        }

        public override void OnUpdate()
        {
            // Back button pressed
            if (OVRInput.GetDown(OVRInput.Button.Back))
            {
                Fsm.Event(backButton);
            }
        }
    }
}