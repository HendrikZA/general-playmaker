// Custom Action by HendrikB
// You can find me on Playmaker forums for suggestions, bugs, fixes or just to say hello :)
// Script is based on OVRInput documentation from Oculus website

using UnityEngine;

namespace HutongGames.PlayMaker.Actions 
{
    
    // Remember to add OVRManager script anywhere in the scene before OVRInput will work.
    [ActionCategory(ActionCategory.Input)]
    [Tooltip("Checks if the touchpad is touched but not pressed down.")]


    public class GetVRDpadTouch : FsmStateAction 
    {

        // Events to send
        [Tooltip("Event to send if DPad was touched but not pressed.")]
        public FsmEvent dpadTouched;

        [Tooltip("Event to send if DPad is no longer being touched.")]
        public FsmEvent dpadReleased;

        // Resets all values to defaults
        public override void Reset()
        {
            dpadTouched = null;
            dpadReleased = null;
        }

        public override void OnUpdate()
        {
            if (OVRInput.Get(OVRInput.Touch.One))
            {
                Fsm.Event(dpadTouched);           
            }

            if (OVRInput.GetUp(OVRInput.Touch.One))
            {
                Fsm.Event(dpadReleased);
            }
        }

        public override string ErrorCheck()
        {
            if (FsmEvent.IsNullOrEmpty(dpadTouched) &&
                FsmEvent.IsNullOrEmpty(dpadReleased))
                return "Action sends no events!";
            return "";
        }
    }
}
