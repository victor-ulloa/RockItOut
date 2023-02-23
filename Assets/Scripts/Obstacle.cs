using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        // Player hit

        if (other.tag == "Player")
        {
            Debug.Log("HIT PLAYER");
            PlayerController player = other.GetComponent<PlayerController>();
            player.lives--;
        }
    }
}
