using UnityEngine;

public class SwipeDetection : MonoBehaviour
{
    [SerializeField] float minimumDistance = .2f;
    [SerializeField] float maximumTime = 1f;

    [Range(0, 1)][SerializeField] float dirThreshold = .9f;


    private Vector2 startPosition;
    private float startTime;

    private Vector2 endPosition;
    private float endTime;

    [SerializeField] float speed = 5;
    [SerializeField] float horizontalSpeed = 100;

    Rigidbody rb;

    private void Awake() {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        Vector3 forwardMove = transform.forward * speed * Time.fixedDeltaTime;
        rb.MovePosition(rb.position + forwardMove);
    }

    private void Update() {
        
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
            Debug.Log("UP");
        }
        if (Vector2.Dot(Vector2.down, directionNormalized) >= dirThreshold)
        {
            Debug.Log("DOWN");
        }
        if (Vector2.Dot(Vector2.left, directionNormalized) >= dirThreshold)
        {
            rb.MovePosition(rb.position - (transform.right * horizontalSpeed * Time.fixedDeltaTime));
            Debug.Log("LEFT");
        }
        if (Vector2.Dot(Vector2.right, directionNormalized) >= dirThreshold)
        {
            rb.MovePosition(rb.position + (transform.right * horizontalSpeed * Time.fixedDeltaTime));
            Debug.Log("RIGHT");
        }
    }
}
