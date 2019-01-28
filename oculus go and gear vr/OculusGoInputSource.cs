// Custom Action by HendrikB
// You can find me on Playmaker forums for suggestions, bugs, fixes or just to say hello :)
// Script allows you to check if controllers are detected, and if so, if it is setup as right-handed or left-handed
// You need the Oculus Utilities for Unity package
// Then find the OVRManager script that comes with Oculus Utilities package and add it to any gameobject in your scene.

using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{

    // Remember to add OVRManager script anywhere in the scene before OVRInput will work.
    [ActionCategory(ActionCategory.Input)]
    [Tooltip("Checks if the controller is connected, and if so, whether it is configured for the left hand or right hand. Checks if only HMD is connected, in which case, we can assume player is using Gear VR without a controller.")]


    public class OculusGoInputSource : FsmStateAction
    {
        [Tooltip("Input source is from a controller that is on the left hand side. You can use just this event, or if you prefer, you can store the bool value below as a variable to use as needed.")]
        public FsmEvent leftControllerConnected;
        [Tooltip("Store the bool value if you prefer instead of using event above. 'true' if controller connected, 'false' if not.")]
        [UIHint(UIHint.Variable)]
        public FsmBool leftControllerConnectedValue;

        
        [Tooltip("Input source is from a controller that is on the right hand side. You can use just this event, or if you prefer, you can store the bool value below as a variable to use as needed.")]
        public FsmEvent rightControllerConnected;
        [Tooltip("Store the bool value if you prefer instead of using event above. 'true' if controller connected, 'false' if not.")]
        [UIHint(UIHint.Variable)]
        public FsmBool rightControllerConnectedValue;

        [Tooltip("Input source is from the headset, which means the player does not have any controllers, and is using only their headset. The player is most likely using a Gear VR with the headset touchpad.")]
        public FsmEvent onlyHeadsetConnected;
        [Tooltip("Store the bool value if you prefer instead of using event above. 'true' if only HMD connected, 'false' if not.")]
        [UIHint(UIHint.Variable)]
        public FsmBool onlyHeadsetConnectedValue;

        // Resets all values to defaults
        public override void Reset()
        {
            leftControllerConnectedValue = false;
            rightControllerConnectedValue = false;
            onlyHeadsetConnectedValue = false;

            leftControllerConnected = null;
            rightControllerConnected = null;
            onlyHeadsetConnected = null;
        }

        public override void OnUpdate()
        {
            // Check Input Source
            if (OVRInput.IsControllerConnected(OVRInput.Controller.LTrackedRemote))
            {
                leftControllerConnectedValue.Value = true;
                Fsm.Event(leftControllerConnected);
            }
            if (OVRInput.IsControllerConnected(OVRInput.Controller.RTrackedRemote))
            {
                rightControllerConnectedValue.Value = true;
                Fsm.Event(rightControllerConnected);
            }
            if (!OVRInput.IsControllerConnected(OVRInput.Controller.LTrackedRemote) &&
                !OVRInput.IsControllerConnected(OVRInput.Controller.RTrackedRemote))
            {
                onlyHeadsetConnectedValue.Value = true;
                Fsm.Event(onlyHeadsetConnected);
            }
        }
    }

}
