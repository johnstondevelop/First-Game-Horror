using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 3f;
    public float lookSensitivity = 0.1f;

    private CharacterController controller;
    private inputAction moveAction;
    private inputAction lookAction;

    void start()
    {
        controller = GetComponent<CharacterController>();
        moveAction = InputSystem.actions.FindAction("Move");
        lookAction = InputSystem.actions.FindAction("look");
    }

    void Update()
    {
        Vector2 input = moveAction.ReadValue<Vector2>();
        Vector2 input = lookInput.ReadValue<Vector2>();
        Debug.Log(input);

        Vector3 moveDirection = transform.forward * input.y + transform.right * input.x;
        transform.Rotate(0f, 1f, 0f);
        controller.Move(moveDirection * moveSpeed * Time.deltaTime);
    }
}