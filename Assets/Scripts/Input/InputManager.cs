using System;
using UnityEngine;
using UnityEngine.InputSystem;

// [DefaultExecutionOrder(-1)]
public class InputManager : Singelton<InputManager>
{

    #region 
    public static event Action<Vector2, float> OnStartTouch;
    public static event Action<Vector2, float> OnEndTouch;
    #endregion

    // [SerializeField] float speed = 5;

    PlayerControls input;
    Camera mainCamera;

    // Rigidbody rb;

    private void Awake()
    {
        // rb = GetComponent<Rigidbody>();
        mainCamera = Camera.main;
        input = new PlayerControls();
    }

    // Start is called before the first frame update
    void Start()
    {
        input.Touch.PrimaryContact.started += ctx => StartTouchPrimary(ctx);
        input.Touch.PrimaryContact.canceled += ctx => EndTouchPrimary(ctx);
    }

    private void FixedUpdate()
    {
        // Vector3 forwardMove = transform.forward * speed * Time.fixedDeltaTime;
        // rb.MovePosition(rb.position + forwardMove);
    }

    // Update is called once per frame
    void Update()
    {

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
        // Debug.Log("START TOUCH");
        // Debug.Log(PrimaryPoisition());
        OnStartTouch?.Invoke(PrimaryPoisition(), (float)context.startTime);
    }

    private void EndTouchPrimary(InputAction.CallbackContext context)
    {
        // Debug.Log("END TOUCH");
        // Debug.Log(PrimaryPoisition());
        OnEndTouch?.Invoke(PrimaryPoisition(), (float)context.time);
    }

    public Vector2 PrimaryPoisition()
    {
        return Utils.ScreenToWorld(mainCamera, input.Touch.PrimaryPosition.ReadValue<Vector2>());
    }
}
