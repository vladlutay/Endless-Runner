using UnityEngine;

public class CameraMovement : MonoBehaviour 
{
    private const int angleRotZ = 90;
    private float currentRotZ = -90;
    [Range(0f, 10f)] [SerializeField] private float speed = 0;
    private Vector2 direction = Vector2.up;
    public SwipeController swipeController;
    [SerializeField] private GameObject character;

    private void Update()
    {
        if (swipeController.IsSwipe)
        {
            CheckDirection();
            swipeController.IsSwipe = false;
        }
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
                currentRotZ -= angleRotZ;
                break;

            case Swipe.LEFT:
                direction = Vector2.left;
                currentRotZ += angleRotZ;
                break;
        }
        //character.GetComponent<SpriteRenderer>().flipX = true;
    }

}
