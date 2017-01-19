using UnityEngine;
using System.Collections;

public static class HGUIHelper
{

    public static Rect PositionLeft(ref Rect rect)
    {
        rect.x = 0;
        return rect;
    }
    public static Rect PositionRight(ref Rect rect)
    {
        rect.x = HGUISizeLocker.m_fScreenWidth - rect.width;
        return rect;
    }
    public static Rect PositionCenter(ref Rect rect)
    {
        rect.x = HGUISizeLocker.m_fScreenWidth / 2 - rect.width / 2;
        rect.y = HGUISizeLocker.m_fScreenHeight / 2 - rect.height / 2;
        return rect;
    }
    public static Rect PositionTop(ref Rect rect)
    {
        rect.y = 0;
        return rect;
    }
    public static Rect PositionBottom(ref Rect rect)
    {
        rect.y = HGUISizeLocker.m_fScreenHeight - rect.height;
        return rect;
    }
}
