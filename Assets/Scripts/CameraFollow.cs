using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] Transform player;
    Vector3 offset;
    
    void Start()
    {
        offset = transform.position = player.position;
        offset.y += 5;
        offset.z -= 10;
    }

    void Update()
    {
        Vector3 targetPosition = player.position + offset;
        targetPosition.x = 0;
        transform.position = targetPosition;
    }
}
