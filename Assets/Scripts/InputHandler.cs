using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem.EnhancedTouch;
using Touch = UnityEngine.InputSystem.EnhancedTouch.Touch;
using TouchPhase = UnityEngine.InputSystem.TouchPhase;

public class InputHandler : MonoBehaviour
{
    private void OnEnable() => EnhancedTouchSupport.Enable();

    private void OnDisable() => EnhancedTouchSupport.Disable();

    private void Update()
    {
        if (Touch.activeTouches.Count > 0)
        {
            Vector3 screenPos = Touch.activeTouches[0].screenPosition;

            if (Touch.activeTouches[0].phase == TouchPhase.Began)
            {

            }
            else if (Touch.activeTouches[0].phase == TouchPhase.Moved)
            {

            }
            else if (Touch.activeTouches[0].phase == TouchPhase.Ended)
            {
                if (!IsPointerOverUIElement(screenPos))
                {
                    Vector3 targetPos = Camera.main.ScreenToWorldPoint(screenPos);
                    targetPos.z = 0;
                    EventManager.ScreenClick(targetPos);
                }
            }
        }
    }

    private bool IsPointerOverUIElement(Vector3 screenPos)
    {
        PointerEventData pointerData = new PointerEventData(EventSystem.current)
        {
            position = screenPos
        };

        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(pointerData, results);

        return results.Count > 0;
    }
}
