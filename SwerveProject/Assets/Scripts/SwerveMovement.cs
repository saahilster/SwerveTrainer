using UnityEngine;
using UnityEngine.InputSystem;

public class SwerveMovement : MonoBehaviour
{
    Vector2 moveDirection = Vector2.zero;
    Vector2 rotationDirection = Vector2.zero;   
    [SerializeField] InputAction playerControls;
    private float moveSpeed = 4.75f;
    private Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnEnable()
    {
        playerControls.Enable();
    }

    private void OnDisable()
    {
        playerControls.Disable();
    }

    // Update is called once per frame
    void Update()
    {
        moveDirection = playerControls.ReadValue<Vector2>();
        rotationDirection = playerControls.ReadValue<Vector2>();
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector3(moveDirection.y * -moveSpeed, 0, moveDirection.x * moveSpeed);
        rb.angularVelocity = new Vector2(0, rotationDirection.x * 1.5F);
        Debug.Log($"Lateral: {moveDirection.x}, Longitudal: {moveDirection.y}");
    }


}
