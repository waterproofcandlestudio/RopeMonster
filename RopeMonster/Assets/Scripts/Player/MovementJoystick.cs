using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MovementJoystick : MonoBehaviour
{
    public GameObject joystick;
    public GameObject joystickBG;

    [HideInInspector]
    public Vector2 joystickVec;

    private Vector2 joystickTouchPos;
    private Vector2 joystickOriginalPos;

    private float joystickRadius;

    // Start is called before the first frame update
    private void Start()
    {
        joystickOriginalPos = joystickBG.transform.position;
        joystickRadius = joystickBG.GetComponent<RectTransform>().sizeDelta.y / 3;
    }

    public void PointerDown()
    {
        joystick.transform.position = Input.mousePosition;
        joystickBG.transform.position = Input.mousePosition;
        joystickTouchPos = Input.mousePosition;
    }

    public void Drag(BaseEventData baseEventData)
    {
        PointerEventData pointer = baseEventData as PointerEventData;
        Vector2 dragPos = pointer.position;

        joystickVec = (dragPos - joystickTouchPos).normalized;

        float joystickDis = Vector2.Distance(dragPos, joystickTouchPos);

        if (joystickDis < joystickRadius)
        {
            joystick.transform.position = joystickTouchPos + joystickVec * joystickDis;
        }
        else
        {
            joystick.transform.position = joystickTouchPos + joystickVec * joystickRadius;
        }
    }

    public void PointerUp()
    {
        joystickVec = Vector2.zero;
        joystick.transform.position = joystickOriginalPos;
        joystickBG.transform.position = joystickOriginalPos;
    }
}