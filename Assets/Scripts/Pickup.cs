using UnityEngine;

public class Pickup : MonoBehaviour
{

    public enum PickupType
    {
        Burger = 0
    }

    [SerializeReference] PickupType pickupType;
    [SerializeField] float turnSpeed = 90f;

    [HideInInspector] public AudioSourceManager sfxManager;
    [SerializeReference] AudioClip pickupSfx;
    
    void Update()
    {
        transform.Rotate(0, turnSpeed * Time.deltaTime, 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag != "Player") { return; }

        switch(pickupType)
        {
            case PickupType.Burger:
                GameManager.Instance.score += 100;
                break;
        }
    sfxManager.Play(pickupSfx);
        Destroy(gameObject);
    }
}
