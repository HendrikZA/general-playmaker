// Custom Action by HendrikB
// You can find me on Playmaker forums for suggestions, bugs, fixes or just to say hello :)
// Script is based on OVRInput documentation from Oculus website

using UnityEngine;

namespace HutongGames.PlayMaker.Actions 
{
    
    // Remember to add OVRManager script anywhere in the scene before OVRInput will work.
    [ActionCategory(ActionCategory.Input)]
    [Tooltip("Checks if the trigger or dpad buttons are being held down. You can use this in two states to check the duration of the button press. One state to check when button is pressed, and another to check when it has been released.")]


    public class GetVRButtonLongPress : FsmStateAction 
    {

        // Events to send
        [Tooltip("Event to send if Trigger button was pressed.")]
        public FsmEvent triggerButton;

        [Tooltip("Event to send if Trigger button was released.")]
        public FsmEvent triggerButtonReleased;

        [Tooltip("Event to send if DPad button was pressed.")]
        public FsmEvent dpadButton;

        [Tooltip("Event to send if DPad button was released.")]
        public FsmEvent dpadButtonReleased;

        // Resets all values to defaults
        public override void Reset()
        {
            triggerButton = null;
            triggerButtonReleased = null;
            dpadButton = null;
            dpadButtonReleased = null;
        }

        public override void OnUpdate()
        {
            if (OVRInput.Get(OVRInput.Button.PrimaryIndexTrigger))
            {
                Fsm.Event(triggerButton);
            }

            if (OVRInput.Get(OVRInput.Button.One))
            {
                Fsm.Event(dpadButton);
            }

            if (OVRInput.GetUp(OVRInput.Button.PrimaryIndexTrigger))
            {
                Fsm.Event(triggerButtonReleased);
            }

            if (OVRInput.GetUp(OVRInput.Button.One))
            {
                Fsm.Event(dpadButtonReleased);
            }
        }

        public override string ErrorCheck()
        {
            if (FsmEvent.IsNullOrEmpty(triggerButton) &&
                FsmEvent.IsNullOrEmpty(triggerButtonReleased) &&
                FsmEvent.IsNullOrEmpty(dpadButton) &&
                FsmEvent.IsNullOrEmpty(dpadButtonReleased))
                return "Action sends no events!";
            return "";
        }
    }
}
