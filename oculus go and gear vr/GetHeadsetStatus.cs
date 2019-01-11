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
    [Tooltip("Checks if the headset has been removed from player face.")]


    public class GetHeadsetStatus : FsmStateAction
    {

        // Events to send if HMD is on face or not.
        [ActionSection("Headset Status")]
        [Tooltip("Sends an event if the headset has been removed.")]
        public FsmEvent headsetRemoved;

        [Tooltip("Sends an event if the headset has been put back on.")]
        public FsmEvent headsetOnFace;

        [Tooltip("Stores the bool value for headset status. If headset is on face, the user is present, and it will be true. If the headset is removed, the user is not present, and it will be false.")]
        [UIHint(UIHint.Variable)]
        public FsmBool isUserPresent;

        // Resets all values to defaults
        public override void Reset()
        {
            headsetRemoved = null;
            headsetOnFace = null;
            isUserPresent = false;
        }

        public override void OnUpdate()
        {
            // Check of user is present and store in bool
            isUserPresent.Value = OVRManager.isUserPresent;

            // Send event if user is present, and thus if headset is on face.
            if (OVRManager.isUserPresent)
            {
                Fsm.Event(headsetOnFace);
            }

            // Send event if user is not present, and thus if headset is removed.
            if (!OVRManager.isUserPresent)
            {
                Fsm.Event(headsetRemoved);
            }
        }
    }
}
