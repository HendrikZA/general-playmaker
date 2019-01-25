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
    [Tooltip("Sends events based on rotation to left or right, or pointing up and down.")]


    public class GetVREvents : FsmStateAction
    {

        // Different types of controller physics we are monitoring.

        [HideInInspector]
        public FsmQuaternion rotation;

        [HideInInspector]
        public FsmFloat x;
        [HideInInspector]
        public FsmFloat y;
        [HideInInspector]
        public FsmFloat z;

        [HideInInspector]
        public FsmVector3 position;
        [HideInInspector]
        public FsmVector3 acceleration;

        // Events
        // Controller rotation to left

        [Tooltip("Sends event if controller rotated left with enough acceleration.")]
        public FsmEvent rotatedLeft;

        [Tooltip("Minimum amount to rotate to the left before regisering as rotated left, e.g. 0.7 is about 70% to the left.  Use 0.5 for a good medium.")]
        public FsmFloat minRotationLeft;

        [Tooltip("Acceleration value minimum when rotating left before registering as enough force.")]
        public FsmFloat accelerationLeft;

        // Controller rotation to right

        [Tooltip("Sends event if controller rotated right with enough acceleration.")]
        public FsmEvent rotatedRight;

        [Tooltip("Minimum amount to rotate to the right before regisering as rotated right, e.g. -0.7 is about 70% to the right. Use -0.5 for a good medium.")]
        public FsmFloat minRotationRight;

        [Tooltip("Acceleration value minimum when rotating right before registering as enough force.")]
        public FsmFloat accelerationRight;

        // Controller pointing up

        [Tooltip("Send event if the controller is pointing directly up.")]
        public FsmEvent pointingUp;

        [Tooltip("-0.1 is the maximum to point before registering as pointing up. Make this lower to decrease amount controller must be pointing up before registering as up, e.g. -0.3.")]
        public FsmFloat upLimit;

        // Controller pointing down

        [Tooltip("Send event if the controller is pointing directly down.")]
        public FsmEvent pointingDown;

        [Tooltip("-0.8 is the maximum to point before registering as pointing down. Make this higher to decrease amount controller must be pointing down before registering as up, e.g. -0.6.")]
        public FsmFloat downLimit;

        // Resets all values to defaults
        public override void Reset()
        {
            rotation = null;
            x = null;
            y = null;
            z = null;
            position = null;
            acceleration = null;
            rotatedLeft = null;
            rotatedRight = null;
            accelerationLeft = -0.5f;
            accelerationRight = 0.5f;
            minRotationLeft = 0.7f;
            minRotationRight = -0.7f;
            pointingUp = null;
            pointingDown = null;
            upLimit = -0.1f;
            downLimit = -0.8f;
        }

        public override void OnUpdate()
        {
            OVRInput.Controller activeController = OVRInput.GetActiveController();

            rotation.Value = OVRInput.GetLocalControllerRotation(activeController);

            x.Value = rotation.Value.x;
            y.Value = rotation.Value.y;
            z.Value = rotation.Value.z;

            position.Value = OVRInput.GetLocalControllerPosition(activeController);

            acceleration.Value = OVRInput.GetLocalControllerAcceleration(activeController);

            // Controller pointing events

            if (position.Value.y >= upLimit.Value)
            {
                Fsm.Event(pointingUp);
            }

            else if (position.Value.y <= downLimit.Value)
            {
                Fsm.Event(pointingDown);
            }

            // Controller rotation events

            if (z.Value >= minRotationLeft.Value && acceleration.Value.z <= accelerationLeft.Value)
            {
                Fsm.Event(rotatedLeft);
            }

            else if (z.Value <= minRotationRight.Value && acceleration.Value.z >= accelerationRight.Value)
            {
                Fsm.Event(rotatedRight);
            }
        }
    }
}
