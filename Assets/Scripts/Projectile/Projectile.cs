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

    private void Update() {
        transform.LookAt(player.transform);
        rb.AddRelativeForce(Vector3.forward * speed, ForceMode.Impulse);
    }

    public void SetTarget(GameObject player)
    {
        this.player = player;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            PlayerController player = other.GetComponent<PlayerController>();
            player.lives--;
        }
    }
}
