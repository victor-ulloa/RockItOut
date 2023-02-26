using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] float speed = 5;
    GameObject player;

    Rigidbody rb;

    private void Awake() {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate() {
        // Vector3 location = player.transform.TransformPoint(Vector3.zero) * speed * Time.fixedDeltaTime;
        // Debug.Log(player.transform.TransformPoint(Vector3.zero));
        // rb.MovePosition(rb.position + location);
    }

    private void Update() {
        Debug.Log(player.transform.position);
        transform.LookAt(player.transform);
        rb.AddRelativeForce(Vector3.forward * speed, ForceMode.Force);
    }

    public void SetTarget(GameObject player)
    {
        this.player = player;
    }
}
