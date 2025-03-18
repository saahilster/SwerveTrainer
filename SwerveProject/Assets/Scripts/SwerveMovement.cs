using UnityEngine;
using UnityEngine.InputSystem;

public class SwerveMovement : MonoBehaviour
{
    Vector2 moveDirection = Vector2.zero;
    float rotationDirection;   
    [SerializeField] InputAction playerControls;
    [SerializeField] private InputAction moveAction;
    [SerializeField] private InputAction rotateAction;
    [SerializeField] private InputAction slowAction;
    private float moveSpeed = 4.75f;
    private float slowSpeed = 1;
    private Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnEnable()
    {
        playerControls.Enable();
        rotateAction.Enable();
        slowAction.Enable();
        slowAction.performed += Slow;
    }

    private void OnDisable()
    {
        playerControls.Disable();
        rotateAction.Disable();
        slowAction.Disable();
        slowAction.performed -= Slow;
    }

    private void Slow(InputAction.CallbackContext context)
    {
        rb.velocity = new Vector3(moveDirection.y * -slowSpeed, 0, moveDirection.x * slowSpeed);
        rb.angularVelocity = new Vector3(0, rotationDirection * 30F, 0);
    }

    // Update is called once per frame
    void Update()
    {
        moveDirection = playerControls.ReadValue<Vector2>();
        rotationDirection = rotateAction.ReadValue<Vector2>().x;
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector3(moveDirection.y * -moveSpeed, 0, moveDirection.x * moveSpeed);
        rb.angularVelocity = new Vector3(0, rotationDirection * 30F, 0);
        Debug.Log($"Lateral: {moveDirection.x}, Longitudal: {moveDirection.y}, Rotational: {rotationDirection}");
        Debug.Log(rb.angularVelocity);
    }


}
