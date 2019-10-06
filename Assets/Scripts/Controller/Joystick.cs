﻿using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Controller
{
    public class Joystick : MonoBehaviour, IPointerDownHandler, IDragHandler, IPointerUpHandler
    {
        public float Horizontal { get { return (snapX) ? SnapFloat(input.x, AxisOptions.HORIZONTAL) : input.x; } }
        public float Vertical { get { return (snapY) ? SnapFloat(input.y, AxisOptions.VERTICAL) : input.y; } }
        public Vector2 Direction { get { return new Vector2(Horizontal, Vertical); } }

        private float HandleRange
        {
            set { handleRange = Mathf.Abs(value); }
        }

        private float DeadZone
        {
            set { deadZone = Mathf.Abs(value); }
        }

        public AxisOptions AxisOptions {
            private get => AxisOptions;
            set { axisOptions = value; } }
        public bool SnapX { get { return snapX; } set { snapX = value; } }
        public bool SnapY { get { return snapY; } set { snapY = value; } }

        [SerializeField] private float handleRange = 1;
        [SerializeField] private float deadZone;
        [SerializeField] private AxisOptions axisOptions = AxisOptions.BOTH;
        [SerializeField] private bool snapX;
        [SerializeField] private bool snapY;

        [SerializeField] protected RectTransform background;
        [SerializeField] private RectTransform handle;
        private RectTransform baseRect;

        private Canvas canvas;
        private Camera cam;

        private Vector2 input = Vector2.zero;

        protected virtual void Start()
        {
            HandleRange = handleRange;
            DeadZone = deadZone;
            baseRect = GetComponent<RectTransform>();
            canvas = GetComponentInParent<Canvas>();
            if (canvas == null)
                Debug.LogError("The Joystick is not placed inside a canvas");

            Vector2 center = new Vector2(0.5f, 0.5f);
            background.pivot = center;
            handle.anchorMin = center;
            handle.anchorMax = center;
            handle.pivot = center;
            handle.anchoredPosition = Vector2.zero;
        }

        public virtual void OnPointerDown(PointerEventData eventData)
        {
            OnDrag(eventData);
        }

        public void OnDrag(PointerEventData eventData)
        {
            cam = null;
            if (canvas.renderMode == RenderMode.ScreenSpaceCamera)
                cam = canvas.worldCamera;

            Vector2 position = RectTransformUtility.WorldToScreenPoint(cam, background.position);
            Vector2 radius = background.sizeDelta / 2;
            input = (eventData.position - position) / (radius * canvas.scaleFactor);
            FormatInput();
            HandleInput(input.magnitude, input.normalized, radius);
            handle.anchoredPosition = input * radius * handleRange;
        }

        protected virtual void HandleInput(float magnitude, Vector2 normalised, Vector2 radius)
        {
            if (magnitude > deadZone)
            {
                if (magnitude > 1)
                    input = normalised;
            }
            else
                input = Vector2.zero;
        }

        private void FormatInput()
        {
            if (axisOptions == AxisOptions.HORIZONTAL)
                input = new Vector2(input.x, 0f);
            else if (axisOptions == AxisOptions.VERTICAL)
                input = new Vector2(0f, input.y);
        }

        private float SnapFloat(float value, AxisOptions snapAxis)
        {
            if (Math.Abs(value) < 0.0f)
                return value;

            if (axisOptions == AxisOptions.BOTH)
            {
                float angle = Vector2.Angle(input, Vector2.up);
                if (snapAxis == AxisOptions.HORIZONTAL)
                {
                    if (angle < 22.5f || angle > 157.5f)
                        return 0;
                    else
                        return (value > 0) ? 1 : -1;
                }
                else if (snapAxis == AxisOptions.VERTICAL)
                {
                    if (angle > 67.5f && angle < 112.5f)
                        return 0;
                    else
                        return (value > 0) ? 1 : -1;
                }
                return value;
            }
            else
            {
                if (value > 0)
                    return 1;
                if (value < 0)
                    return -1;
            }
            return 0;
        }

        public virtual void OnPointerUp(PointerEventData eventData)
        {
            input = Vector2.zero;
            handle.anchoredPosition = Vector2.zero;
        }

        protected Vector2 ScreenPointToAnchoredPosition(Vector2 screenPosition)
        {
            if (RectTransformUtility.ScreenPointToLocalPointInRectangle(baseRect, screenPosition, cam, out var localPoint))
            {
                Vector2 sizeDelta;
                var pivotOffset = baseRect.pivot * (sizeDelta = baseRect.sizeDelta);
                return localPoint - (background.anchorMax * sizeDelta) + pivotOffset;
            }
            return Vector2.zero;
        }
    }

    public enum AxisOptions { BOTH, HORIZONTAL, VERTICAL }
}