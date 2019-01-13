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
    [Tooltip("Checks the current rotation and position of the Oculus Go or Gear VR controller.")]


    public class GetVRControllerRotation : FsmStateAction
    {

        // Controller rotation and position
        [ActionSection("Controller Rotation")]
        [Tooltip("Gets the current rotation of the controller.")]
        [UIHint(UIHint.Variable)]
        public FsmQuaternion controllerRotation;

        [ActionSection("Controller Position")]
        [Tooltip("Gets the current position of the controller.")]
        [UIHint(UIHint.Variable)]
        public FsmVector3 controllerPosition;

        // Resets all values to defaults
        public override void Reset()
        {
            controllerRotation = null;
            controllerPosition = null;
        }

        public override void OnUpdate()
        {
            // Get controller rotation
            if (OVRInput.IsControllerConnected(OVRInput.Controller.RTrackedRemote))
            {
                controllerRotation.Value = OVRInput.GetLocalControllerRotation(OVRInput.Controller.RTrackedRemote);
                controllerPosition.Value = OVRInput.GetLocalControllerPosition(OVRInput.Controller.RTrackedRemote);
            }

            // Get controller position
            if (OVRInput.IsControllerConnected(OVRInput.Controller.LTrackedRemote))
            {
                controllerRotation.Value = OVRInput.GetLocalControllerRotation(OVRInput.Controller.LTrackedRemote);
                controllerPosition.Value = OVRInput.GetLocalControllerPosition(OVRInput.Controller.LTrackedRemote);
            }
        }
    }
}
