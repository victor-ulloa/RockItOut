using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileSpawn : MonoBehaviour
{
    [SerializeField] float period = 5f;
    [SerializeField] GameObject projectile;
    [SerializeField] GameObject player;
    float nextActionTime = 0.0f;

    void Update()
    {
        if (Time.time > nextActionTime)
        {
            nextActionTime += period;
            GameObject tempObject = Instantiate(projectile, transform.position, Quaternion.identity);
            tempObject.GetComponent<Projectile>().SetTarget(player);
            
        }
    }
}
