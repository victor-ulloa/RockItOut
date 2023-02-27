using UnityEngine;

public class SwipeDetection : MonoBehaviour
{
    [SerializeField] float minimumDistance = .2f;
    [SerializeField] float maximumTime = 1f;

    [Range(0, 1)][SerializeField] float dirThreshold = .9f;

    PlayerController player;

    private Vector2 startPosition;
    private float startTime;

    private Vector2 endPosition;
    private float endTime;

    private void Awake()
    {
        player = GetComponent<PlayerController>();
    }

    private void OnEnable()
    {
        InputManager.OnStartTouch += SwipeStart;
        InputManager.OnEndTouch += SwipeEnd;
    }

    private void OnDisable()
    {
        InputManager.OnStartTouch -= SwipeStart;
        InputManager.OnEndTouch -= SwipeEnd;
    }

    private void SwipeStart(Vector2 position, float time)
    {
        startPosition = position;
        startTime = time;
    }

    private void SwipeEnd(Vector2 position, float time)
    {
        endPosition = position;
        endTime = time;
        CheckSwipe();
    }

    private void CheckSwipe()
    {
        if (Vector3.Distance(startPosition, endPosition) >= minimumDistance && (endTime - startTime) <= maximumTime)
        {
            Vector3 swipeDirection = endPosition - startPosition;
            Vector2 swipeDirection2D = new Vector2(swipeDirection.x, swipeDirection.y);
            SwipeDirection(swipeDirection2D);
        }
    }

    void SwipeDirection(Vector2 direction)
    {
        Vector2 directionNormalized = direction.normalized;

        if (Vector2.Dot(Vector2.up, directionNormalized) >= dirThreshold)
        {
            player.Jump();
        }
        // if (Vector2.Dot(Vector2.down, directionNormalized) >= dirThreshold)
        // {
        //     Debug.Log("DOWN");
        // }
        if (Vector2.Dot(Vector2.left, directionNormalized) >= dirThreshold)
        {
            player.MoveLeft();
        }
        if (Vector2.Dot(Vector2.right, directionNormalized) >= dirThreshold)
        {
            player.MoveRight();
        }
    }
}
