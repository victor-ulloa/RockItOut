using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : Singelton<InputManager>
{

    #region 
    public static event Action<Vector2, float> OnStartTouch;
    public static event Action<Vector2, float> OnEndTouch;
    #endregion

    PlayerControls input;
    Camera mainCamera;

    private void Awake()
    {
        mainCamera = Camera.main;
        input = new PlayerControls();
    }

    void Start()
    {
        input.Touch.PrimaryContact.started += ctx => StartTouchPrimary(ctx);
        input.Touch.PrimaryContact.canceled += ctx => EndTouchPrimary(ctx);
        input.Touch.PrimaryPosition.performed += ctx => OnTouch(ctx);
    }

    private void OnEnable()
    {
        input.Enable();
    }

    private void OnDisable()
    {
        input.Disable();
    }

    private void StartTouchPrimary(InputAction.CallbackContext context)
    {
        OnStartTouch?.Invoke(PrimaryPoisition(), (float)context.startTime);
    }

    private void EndTouchPrimary(InputAction.CallbackContext context)
    {
        OnEndTouch?.Invoke(PrimaryPoisition(), (float)context.time);
    }

    private void OnTouch(InputAction.CallbackContext context)
    {
        Ray raycast = Camera.main.ScreenPointToRay(context.ReadValue<Vector2>());
        RaycastHit raycastHit;
        if (Physics.Raycast(raycast, out raycastHit))
        {
            if (raycastHit.collider.CompareTag("Projectile"))
            {
                GameManager.Instance.score += 100;
                Destroy(raycastHit.collider.gameObject);
            }
        }
    }

    public Vector2 PrimaryPoisition()
    {
        return Utils.ScreenToWorld(mainCamera, input.Touch.PrimaryPosition.ReadValue<Vector2>());
    }
}
