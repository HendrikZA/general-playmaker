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
    [Tooltip("Checks if the Oculus Go, or Gear VR, capacitive touchpad has been touched in a specific direction. If preferred you can just get the touched axis and use it as a variable.")]


    public class OculusGoCapacitiveTouch : FsmStateAction
    {
        // Events to send
        // Touchpad axis
        [ActionSection("Touchpad Axis")]
        [Tooltip("Checks finger position on the touchpad. Can be used for FPS movement and all kinds of useful things.")]
        [UIHint(UIHint.Variable)]
        public FsmVector2 touchpadAxis;

        // Capacitive Surface Touched
        [ActionSection("Capacitive Surface")]
        [Tooltip("Checks if capacitive surface of touchpad is being touched towards the top.")]
        public FsmEvent capacitiveTouchedUp;
        [Tooltip("Capacitive surface upward press sensitivity. How far should the surface be touched to the top of the capacitive surface before it triggers as being pressed up? Defaults to 0.5, which means about 50% up from centre. This feels just right, but you can set it less or more depending on your needs.")]
        public FsmFloat capacitiveUpSensitivity = 0.5f;

        [Tooltip("Checks if capacitive surface of touchpad is being touched towards the bottom.")]
        public FsmEvent capacitiveTouchedDown;
        [Tooltip("Capacitive surface downward press sensitivity. How far should the surface be touched to the bottom of the capacitive surface before it triggers as being pressed down? Defaults to 0.5, which means about 50% down from centre. This feels just right, but you can set it less or more depending on your needs.")]
        public FsmFloat capacitiveDownSensitivity = -0.5f;

        [Tooltip("Checks if capacitive surface of touchpad is being touched towards the left.")]
        public FsmEvent capacitiveTouchedLeft;
        [Tooltip("Capacitive surface left press sensitivity. How far should the surface be touched to the left of the capacitive surface before it triggers as being pressed left? Defaults to 0.5, which means about 50% left from centre. This feels just right, but you can set it less or more depending on your needs.")]
        public FsmFloat capacitiveLeftSensitivity = -0.5f;

        [Tooltip("Checks if capacitive surface of touchpad is being touched towards the right.")]
        public FsmEvent capacitiveTouchedRight;
        [Tooltip("Capacitive surface right press sensitivity. How far should the surface be touched to the right of the capacitive surface before it triggers as being pressed right? Defaults to 0.5, which means about 50% right from centre. This feels just right, but you can set it less or more depending on your needs.")]
        public FsmFloat capacitiveRightSensitivity = 0.5f;

        // Resets all values to defaults
        public override void Reset()
        {
            touchpadAxis = null;
            capacitiveTouchedUp = null;
            capacitiveTouchedDown = null;
            capacitiveTouchedLeft = null;
            capacitiveTouchedRight = null;
            capacitiveUpSensitivity = 0.5f;
            capacitiveDownSensitivity = -0.5f;
            capacitiveLeftSensitivity = -0.5f;
            capacitiveRightSensitivity = 0.5f;
        }

        public override void OnUpdate()
        {
            // Touchpad axis
            touchpadAxis.Value = OVRInput.Get(OVRInput.Axis2D.PrimaryTouchpad);

            // Capacitive surface touched in a specific direction
            if (touchpadAxis.Value.x > capacitiveRightSensitivity.Value)
            {
                Fsm.Event(capacitiveTouchedRight);
            }
            if (touchpadAxis.Value.x < capacitiveLeftSensitivity.Value)
            {
                Fsm.Event(capacitiveTouchedLeft);
            }
            if (touchpadAxis.Value.y > capacitiveUpSensitivity.Value)
            {
                Fsm.Event(capacitiveTouchedUp);
            }
            if (touchpadAxis.Value.y < capacitiveDownSensitivity.Value)
            {
                Fsm.Event(capacitiveTouchedDown);
            }
        }
    }
}
