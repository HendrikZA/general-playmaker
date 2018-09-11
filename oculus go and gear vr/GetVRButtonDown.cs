// Custom Action by HendrikB
// You can find me on Playmaker forums for suggestions, bugs, fixes or just to say hello :)
// Script is based on OVRInput documentation from Oculus website

using UnityEngine;

namespace HutongGames.PlayMaker.Actions 
{
    
    // Remember to add OVRManager script anywhere in the scene before OVRInput will work.
    [ActionCategory(ActionCategory.Custom)]
    [Tooltip("Checks if the Oculus Go, or Gear VR, controller buttons have been pressed.")]


    public class GetVRButtonDown : FsmStateAction 
    {

        // Events to send
        [Tooltip("Event to send if Trigger button was pressed.")]
        public FsmEvent triggerButton;

        [Tooltip("Event to send if Back button was pressed.")]
        public FsmEvent backButton;

        [Tooltip("Event to send if DPad button was pressed.")]
        public FsmEvent dpadButton;

        [Tooltip("Event to send if DPad was swiped up.")]
        public FsmEvent dpadSwipeUp;

        [Tooltip("Event to send if DPad was swiped down.")]
        public FsmEvent dpadSwipeDown;

        [Tooltip("Event to send if DPad was swiped left.")]
        public FsmEvent dpadSwipeLeft;

        [Tooltip("Event to send if DPad was swiped right.")]
        public FsmEvent dpadSwipeRight;

        // Resets all values to defaults
        public override void Reset()
        {
            triggerButton = null;
            backButton = null;
            dpadButton = null;
            dpadSwipeUp = null;
            dpadSwipeDown = null;
            dpadSwipeLeft = null;
            dpadSwipeRight = null;
        }

        public override void OnUpdate()
        {
            if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger))
            {
                Fsm.Event(triggerButton);
            }

            if (OVRInput.GetDown(OVRInput.Button.Back))
            {
                Fsm.Event(backButton);
            }

            if (OVRInput.GetDown(OVRInput.Button.One))
            {
                Fsm.Event(dpadButton);
            }

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

        public override string ErrorCheck()
        {
            if (FsmEvent.IsNullOrEmpty(triggerButton) &&
                FsmEvent.IsNullOrEmpty(backButton) &&
                FsmEvent.IsNullOrEmpty(dpadButton) &&
                FsmEvent.IsNullOrEmpty(dpadSwipeUp) &&
                FsmEvent.IsNullOrEmpty(dpadSwipeDown) &&
                FsmEvent.IsNullOrEmpty(dpadSwipeLeft) &&
                FsmEvent.IsNullOrEmpty(dpadSwipeRight))
                return "Action sends no events!";
            return "";
        }
    }
}