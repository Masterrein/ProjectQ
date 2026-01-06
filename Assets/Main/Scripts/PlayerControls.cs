using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControls : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;        // units per second
    [SerializeField] private float rotationSpeed = 180f;  // degrees per second

    private InputAction moveAction;

    private void Awake()
    {
        SetMovementBinding();
    }

    private void OnEnable()
    {
        moveAction.Enable();
    }

    private void OnDisable()
    {
        moveAction.Disable();
    }

    private void Update()
    {
        MovePlayer();
    }

    private void SetMovementBinding() 
    {
        // Create a simple 2D composite binding for WASD:
        // - W / S map to the Y axis (forward/back)
        // - A / D map to the X axis (left/right) which we use for rotation
        moveAction = new InputAction(
            name: "Move",
            type: InputActionType.Value,
            expectedControlType: "Vector2"
        );

        moveAction.AddCompositeBinding("2DVector")
            .With("Up", "<Keyboard>/w")
            .With("Down", "<Keyboard>/s")
            .With("Left", "<Keyboard>/a")
            .With("Right", "<Keyboard>/d");
    }

    private void MovePlayer() {
        Vector2 input = moveAction.ReadValue<Vector2>();

        // Forward/back movement (W/S)
        float forwardAmount = input.y;
        if (!Mathf.Approximately(forwardAmount, 0f))
        {
            transform.position += forwardAmount * moveSpeed * Time.deltaTime * transform.forward;
        }

        // Rotation left/right (A/D)
        float turnAmount = input.x;
        if (!Mathf.Approximately(turnAmount, 0f))
        {
            transform.Rotate(0f, turnAmount * rotationSpeed * Time.deltaTime, 0f, Space.Self);
        }
    }
}
