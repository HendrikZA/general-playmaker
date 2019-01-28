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
    [Tooltip("Gets the rotation, velocity, acceleration and position of the active controller.")]


    public class OculusGoPhysics : FsmStateAction
    {

        // Different types of controller physics we are monitoring.

        [Tooltip("Gets the rotation of the controller.")]
        [UIHint(UIHint.Variable)]
        public FsmQuaternion rotation;

        [Tooltip("Gets the angular velocity of the controller.")]
        [UIHint(UIHint.Variable)]
        public FsmVector3 angularVelocity;

        [Tooltip("Gets the angular acceleration of the controller.")]
        [UIHint(UIHint.Variable)]
        public FsmVector3 angularAcceleration;

        [Tooltip("Gets the position of the controller.")]
        [UIHint(UIHint.Variable)]
        public FsmVector3 position;

        [Tooltip("Gets the velocity of the controller.")]
        [UIHint(UIHint.Variable)]
        public FsmVector3 velocity;

        [Tooltip("Gets the acceleration of the controller.")]
        [UIHint(UIHint.Variable)]
        public FsmVector3 acceleration;

        // Resets all values to defaults
        public override void Reset()
        {
            rotation = null;
            angularVelocity = null;
            angularAcceleration = null;
            position = null;
            velocity = null;
            acceleration = null;
        }

        public override void OnUpdate()
        {
            OVRInput.Controller activeController = OVRInput.GetActiveController();

            rotation.Value = OVRInput.GetLocalControllerRotation(activeController);

            angularVelocity.Value = OVRInput.GetLocalControllerAngularVelocity(activeController);

            angularAcceleration.Value = OVRInput.GetLocalControllerAngularAcceleration(activeController);

            position.Value = OVRInput.GetLocalControllerPosition(activeController);

            velocity.Value = OVRInput.GetLocalControllerVelocity(activeController);

            acceleration.Value = OVRInput.GetLocalControllerAcceleration(activeController);
        }
    }
}
