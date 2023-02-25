using UnityEngine;
using UnityEngine.Events;

public class PlayerController : MonoBehaviour
{
    [SerializeField] int maxLives = 5;

    [SerializeField] float speed = 10f;
    [SerializeField] float horizontalSpeed = 125f;
    [SerializeField] float jumpForce = 100f;
    [SerializeField] bool isGrounded;

    [SerializeField] LayerMask groundMask;

    [HideInInspector] public UnityEvent<int> OnLifeValueChaged;

    Rigidbody rb;
    Animator animator;

    private int _lives = 3;
    public int lives
    {
        get { return _lives; }
        set
        {

            if (_lives > value)
            {
                // lost 1 live
            }

            if (value <= 0)
            {
                GameManager.Instance.RestartLevel();
            }

            _lives = value;
            if (_lives > maxLives)
            {
                _lives = maxLives;
            }
            OnLifeValueChaged.Invoke(_lives);
            Debug.Log("Lives are set to:" + lives.ToString());
        }
    }

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        Vector3 forwardMove = transform.forward * speed * Time.fixedDeltaTime;
        rb.MovePosition(rb.position + forwardMove);
        
    }

    private void Update()
    {
        if (transform.position.y < -5)
        {
            lives = 0;
        }
        
        isGrounded = Physics.Raycast(transform.position, Vector3.down, 0.1f, groundMask);
        animator.SetBool("isGrounded", isGrounded);
    }

    public void MoveLeft()
    {
        rb.MovePosition(rb.position - (transform.right * horizontalSpeed * Time.fixedDeltaTime));
    }

    public void MoveRight()
    {
        rb.MovePosition(rb.position + (transform.right * horizontalSpeed * Time.fixedDeltaTime));
    }

    public void Jump()
    {
        if (isGrounded) {
            rb.AddForce(Vector3.up * jumpForce);
        }
    }
}
