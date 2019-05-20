using UnityEngine;
using UnityEngine.EventSystems;

enum Swipe { LEFT, RIGHT, UP, DOWN };

public class SwipeController : MonoBehaviour, IDragHandler, IBeginDragHandler
{
    private Swipe currentSwipe = Swipe.UP; // Default

    internal Swipe CurrentSwipe
    {
        get
        {
            return currentSwipe;
        }
    }

    void IBeginDragHandler.OnBeginDrag(PointerEventData eventData)
    {
        if(eventData.delta.x > 0) // Right
        {
            currentSwipe = Swipe.RIGHT;
        }
        if(eventData.delta.x < 0) // Left
        {
            currentSwipe = Swipe.LEFT;
        }
        if(eventData.delta.y > 0) // Up
        {
            currentSwipe = Swipe.UP;
        }
        if(eventData.delta.y < 0) // Down
        {
            currentSwipe = Swipe.DOWN;
        }

    }

    void IDragHandler.OnDrag(PointerEventData eventData)
    {

    }

}
