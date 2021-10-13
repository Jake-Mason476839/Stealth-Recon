using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class VJMovement : MonoBehaviour, IDragHandler, IPointerUpHandler, IPointerDownHandler
{
    private Image joystickBackground;
    private Image joystick;
    public Vector3 InputDirection;

    void Start()
    {
        joystickBackground = GetComponent<Image>();
        joystick = transform.GetChild(0).GetComponent<Image>();
        InputDirection = Vector3.zero;
    }

    public void OnDrag(PointerEventData ped)
    {
        Vector2 position = Vector2.zero;

        RectTransformUtility.ScreenPointToLocalPointInRectangle(joystickBackground.rectTransform, ped.position, ped.pressEventCamera, out position);

        position.x = (position.x / joystickBackground.rectTransform.sizeDelta.x);
        position.y = (position.y / joystickBackground.rectTransform.sizeDelta.y);

        float x = (joystickBackground.rectTransform.pivot.x == 1f) ? position.x * 2 + 1 : position.x * 2 - 1;
        float y = (joystickBackground.rectTransform.pivot.y == 1f) ? position.y * 2 + 1 : position.y * 2 - 1;

        InputDirection = new Vector3(x, y, 0);
        InputDirection = (InputDirection.magnitude > 1) ? InputDirection.normalized : InputDirection;

        joystick.rectTransform.anchoredPosition = new Vector3(InputDirection.x * (joystickBackground.rectTransform.sizeDelta.x / 3), InputDirection.y * (joystickBackground.rectTransform.sizeDelta.y / 3));
    }

    public void OnPointerDown(PointerEventData ped)
    {
        OnDrag(ped);
    }

    public void OnPointerUp(PointerEventData ped)
    {
        InputDirection = Vector3.zero;
        joystick.rectTransform.anchoredPosition = Vector3.zero;
    }
}
