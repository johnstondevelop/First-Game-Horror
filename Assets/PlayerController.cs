using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 3f;
    public float lookSensitivity = 0.1f;
    public Transform cameraTransform;
    public float gravity = -9.81f;

    private CharacterController controller;
    private InputAction moveAction;
    private InputAction lookAction;
    private float cameraPitch = 0f;
    private float verticalVelocity = 0f;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        moveAction = InputSystem.actions.FindAction("Move");
        lookAction = InputSystem.actions.FindAction("Look");
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        Vector2 input = moveAction.ReadValue<Vector2>();
        Vector2 lookInput = lookAction.ReadValue<Vector2>();
        Debug.Log(input);

        if (controller.isGrounded && verticalVelocity < 0f){
            verticalVelocity = -2f;
        }

        verticalVelocity += gravity * Time.deltaTime;
        Vector3 moveDirection = transform.forward * input.y + transform.right * input.x;
        transform.Rotate(0f, lookSensitivity * lookInput.x, 0f);
        cameraPitch -= lookSensitivity * lookInput.y;
        cameraPitch = Mathf.Clamp(cameraPitch, -80f, 80f);
        Vector3 velocity = moveDirection * moveSpeed;
        velocity.y = verticalVelocity;
        controller.Move(velocity * Time.deltaTime);

        cameraTransform.localRotation = Quaternion.Euler(cameraPitch, 0f, 0f);
    }
}