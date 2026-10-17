using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControllerX : MonoBehaviour {
    public float speed;
    public float rotationSpeed;

    // Input System action for controller input
    public InputAction MoveAction;

    // Current input value
    // X = left/right
    // Y = up/down
    private Vector2 moveInput;

    void Start() {
        MoveAction.Enable(); // Enable MoveAction so it starts reading input
    }

    void FixedUpdate() {
        moveInput = MoveAction.ReadValue<Vector2>(); // Read the 2D vector from the MoveAction

        // Calculate the plane's current speed based on horizontal input
        // Left = decreased speed
        // Right = increased speed
        float currentSpeed = speed * (1 + 0.3f * moveInput.x); 

        // Move the plane forward 
        transform.Translate(Vector3.forward * Time.deltaTime * currentSpeed);

        // Tilt the plane up/down
        transform.Rotate(Vector3.left * rotationSpeed * Time.deltaTime * moveInput.y);
    }
}
