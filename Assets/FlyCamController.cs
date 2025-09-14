using UnityEngine;
using UnityEngine.InputSystem;

public class FlyCamController : MonoBehaviour
{
    [Header("Settings")]
    public float moveSpeed = 20f;
    public float sprintMultiplier = 5f;
    public float lookSensitivity = 0.5f;

    private InputSystem_Actions inputActions;
    private Vector2 moveInput;
    private Vector2 lookInput;
    private float pitch;
    private float yaw;

    void Awake()
    {
        inputActions = new InputSystem_Actions();
    }

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void OnEnable()
    {
        inputActions.Enable();
        inputActions.Player.Move.performed += ctx => moveInput = ctx.ReadValue<Vector2>();
        inputActions.Player.Move.canceled += ctx => moveInput = Vector2.zero;

        inputActions.Player.Look.performed += ctx => lookInput = ctx.ReadValue<Vector2>();
        inputActions.Player.Look.canceled += ctx => lookInput = Vector2.zero;
    }

    void OnDisable()
    {
        inputActions.Disable();
    }

    void Update()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        HandleMovement();
        HandleLook();   


    }

    private void HandleMovement()
    {
        // WASD movement
        Vector3 forward = transform.forward;
        Vector3 right = transform.right;

        // Normalize to prevent diagonal speed boost
        Vector3 direction = (forward * moveInput.y + right * moveInput.x).normalized;

        // Hold Left Shift to sprint
        float speed = moveSpeed;
        if (Keyboard.current.leftShiftKey.isPressed)
            speed *= sprintMultiplier;

        transform.position += direction * speed * Time.deltaTime;
    }

    private void HandleLook()
    {
        yaw += lookInput.x * lookSensitivity;
        pitch -= lookInput.y * lookSensitivity;
        pitch = Mathf.Clamp(pitch, -89f, 89f); // Prevent flipping

        transform.rotation = Quaternion.Euler(pitch, yaw, 0f);
    }
}
