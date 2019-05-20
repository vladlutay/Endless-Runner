using UnityEngine;
using UnityEngine.EventSystems;

enum Swipe { LEFT, RIGHT, UP, DOWN };

public class SwipeController : MonoBehaviour, IDragHandler, IBeginDragHandler
{
    private Swipe currentSwipe = Swipe.UP; // Default
    private bool isSwipe = false;
    private const int swipeRange = 0;
    private const float swipeDistance = 300f;
    public UnityEngine.UI.Text button;
    public bool IsSwipe
    {
        get
        {
            return isSwipe;
        }
        set
        {
            isSwipe = value;
        }
    }

    internal Swipe CurrentSwipe
    {
        get
        {
            return currentSwipe;
        }
    }

    void IBeginDragHandler.OnBeginDrag(PointerEventData eventData)
    {
        if (eventData.delta.sqrMagnitude > swipeDistance)
        {
            if (Mathf.Abs(eventData.delta.x) > Mathf.Abs(eventData.delta.y))
            {
                if (eventData.delta.x > swipeRange) // Right
                {
                    currentSwipe = Swipe.RIGHT;
                }
                else if (eventData.delta.x < swipeRange)// Left
                {

                    currentSwipe = Swipe.LEFT;
                }
            }
            else
            {
                if (eventData.delta.y > swipeRange) // Up
                {
                    currentSwipe = Swipe.UP;
                }
                else if (eventData.delta.y < swipeRange)// Down
                {
                    currentSwipe = Swipe.DOWN;
                }
            }
            isSwipe = true;
        }
    }
    void IDragHandler.OnDrag(PointerEventData eventData) { }

}
