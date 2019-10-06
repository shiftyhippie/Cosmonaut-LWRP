using UnityEngine;
using UnityEngine.EventSystems;

namespace Controller
{
    public class VariableJoystick : Joystick
    {
        public float MoveThreshold { get { return moveThreshold; } set { moveThreshold = Mathf.Abs(value); } }

        [SerializeField] private float moveThreshold = 1;
        [SerializeField] private JoystickType joystickType = JoystickType.FIXED;

        private Vector2 fixedPosition = Vector2.zero;

        private void SetMode(JoystickType setModeJoystickType)
        {
            joystickType = setModeJoystickType;
            if(setModeJoystickType == JoystickType.FIXED)
            {
                background.anchoredPosition = fixedPosition;
                background.gameObject.SetActive(true);
            }
            else
                background.gameObject.SetActive(false);
        }

        protected override void Start()
        {
            base.Start();
            fixedPosition = background.anchoredPosition;
            SetMode(joystickType);
        }

        public override void OnPointerDown(PointerEventData eventData)
        {
            if(joystickType != JoystickType.FIXED)
            {
                background.anchoredPosition = ScreenPointToAnchoredPosition(eventData.position);
                background.gameObject.SetActive(true);
            }
            base.OnPointerDown(eventData);
        }

        public override void OnPointerUp(PointerEventData eventData)
        {
            if(joystickType != JoystickType.FIXED)
                background.gameObject.SetActive(false);

            base.OnPointerUp(eventData);
        }

        protected override void HandleInput(float magnitude, Vector2 normalised, Vector2 radius)
        {
            if (joystickType == JoystickType.DYNAMIC && magnitude > moveThreshold)
            {
                Vector2 difference = normalised * (magnitude - moveThreshold) * radius;
                background.anchoredPosition += difference;
            }
            base.HandleInput(magnitude, normalised, radius);
        }
    }

    public enum JoystickType { FIXED, FLOATING, DYNAMIC }
}