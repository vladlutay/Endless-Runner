using UnityEngine;

public class CameraMovement : MonoBehaviour 
{
    [Range(0f, 10f)] [SerializeField] private float speed = 0;
    private Vector2 direction = Vector2.up;
    public SwipeController swipeController;

    private void Update()
    {
        CheckDirection();
        transform.Translate(direction * speed * Time.deltaTime);
    }

    private void CheckDirection()
    {
        switch (swipeController.CurrentSwipe)
        {
            case Swipe.UP:
                direction = Vector2.up;
                break;

            case Swipe.DOWN:
                direction = Vector2.down;
                break;

            case Swipe.RIGHT:
                direction = Vector2.right;
                break;

            case Swipe.LEFT:
                direction = Vector2.left;
                break;
        }
    }

}
