// Custom Action by HendrikB
// You can find me on Playmaker forums for suggestions, bugs, fixes or just to say hello :)
// Script is based on OVRInput documentation from Oculus website

using UnityEngine;

namespace HutongGames.PlayMaker.Actions 
{
    
    // Remember to add OVRManager script anywhere in the scene before OVRInput will work.
    [ActionCategory(ActionCategory.Input)]
    [Tooltip("Checks if the trigger or dpad buttons have been released.")]


    public class GetVRButtonUp : FsmStateAction 
    {

        // Events to send
        [Tooltip("Event to send if Trigger button was released.")]
        public FsmEvent triggerButton;

        [Tooltip("Event to send if DPad button was released.")]
        public FsmEvent dpadButton;

        // Resets all values to defaults
        public override void Reset()
        {
            triggerButton = null;
            dpadButton = null;
        }

        public override void OnUpdate()
        {
            if (OVRInput.GetUp(OVRInput.Button.PrimaryIndexTrigger))
            {
                Fsm.Event(triggerButton);
            }

            if (OVRInput.GetUp(OVRInput.Button.One))
            {
                Fsm.Event(dpadButton);
            }
        }

        public override string ErrorCheck()
        {
            if (FsmEvent.IsNullOrEmpty(triggerButton) &&
                FsmEvent.IsNullOrEmpty(dpadButton))
                return "Action sends no events!";
            return "";
        }
    }
}