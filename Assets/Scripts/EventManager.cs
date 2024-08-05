using System;
using UnityEngine;

public static class EventManager 
{
    public static Action<Vector3> OnScreenClick;

    public static void ScreenClick(Vector3 screenPos)
    {
        OnScreenClick?.Invoke(screenPos);
    }
}
