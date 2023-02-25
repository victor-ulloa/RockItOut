using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] int maxLives = 5;

    [SerializeField] float speed = 10f;
    [SerializeField] float horizontalSpeed = 125f;
    [SerializeField] float jumpForce = 100f;
    [SerializeField] bool isGrounded;

    [SerializeField] LayerMask groundMask;

    Rigidbody rb;

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
            Debug.Log("Lives are set to:" + lives.ToString());
        }
    }

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
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
        
        isGrounded = Physics.Raycast(transform.position, Vector3.down, (GetComponent<Collider>().bounds.size.y / 2) + 0.1f, groundMask);
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
