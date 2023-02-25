using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] int maxLives = 5;

    [SerializeField] float speed = 10;
    [SerializeField] float horizontalSpeed = 125;

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

    }
}
