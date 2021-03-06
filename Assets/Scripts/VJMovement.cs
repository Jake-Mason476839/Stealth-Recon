using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class VJMovement : MonoBehaviour, IDragHandler, IPointerUpHandler, IPointerDownHandler
{
    private Image joystickBackground;
    private Image joystick;
    public Vector3 inputDirection;

    void Start()
    {
        joystickBackground = GetComponent<Image>(); //This gets the background image of the joystick
        joystick = transform.GetChild(0).GetComponent<Image>(); 
        inputDirection = Vector3.zero;
    }

    public void OnDrag(PointerEventData ped)
    {
        Vector2 position = Vector2.zero;

        RectTransformUtility.ScreenPointToLocalPointInRectangle(joystickBackground.rectTransform, ped.position, ped.pressEventCamera, out position);

        position.x = (position.x / joystickBackground.rectTransform.sizeDelta.x); //These two lines get the starting position of the joystick on the joysticks background.
        position.y = (position.y / joystickBackground.rectTransform.sizeDelta.y); 

        float x = (joystickBackground.rectTransform.pivot.x == 1f) ? position.x * 2 + 1 : position.x * 2 - 1;
        float y = (joystickBackground.rectTransform.pivot.y == 1f) ? position.y * 2 + 1 : position.y * 2 - 1;

        inputDirection = new Vector3(x, y, 0);
        inputDirection = (inputDirection.magnitude > 1) ? inputDirection.normalized : inputDirection;

        joystick.rectTransform.anchoredPosition = new Vector3(inputDirection.x * (joystickBackground.rectTransform.sizeDelta.x / 3), inputDirection.y * (joystickBackground.rectTransform.sizeDelta.y / 3));
    }

    public void OnPointerDown(PointerEventData ped)
    {
        OnDrag(ped); //This line detects when the user is dragging the joystick around.
    }

    public void OnPointerUp(PointerEventData ped)
    {
        inputDirection = Vector3.zero;
        joystick.rectTransform.anchoredPosition = Vector3.zero;
        //The use of this code is to return the joystick to its orignal starting position after the user has let go of the joystick.
    }
}
