using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerContr : MonoBehaviour
{
    float inputX;
    float inputY;
    private Rigidbody rb;
    public float speed = 10.0f;
    public PlayerInput input;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       input = GetComponent<PlayerInput>();
        rb = GetComponent<Rigidbody>();

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 tempmove = rb.linearVelocity;
        rb.linearVelocity = (tempmove.x * transform.forward) + (tempmove.y * transform.up) + (tempmove.z * transform.right);
        tempmove.x = inputY * speed;
        tempmove.z = inputX * speed;
    }
    public void Move(InputAction.CallbackContext context)
    {
        {
            Vector2 InputAxis = context.ReadValue<Vector2>();
            inputX = InputAxis.x;
            inputY = InputAxis.y;
        }
    }
}

