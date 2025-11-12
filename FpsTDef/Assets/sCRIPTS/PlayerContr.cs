
using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerContr : MonoBehaviour


{


    private Rigidbody rb;
    float inputX;
    float inputY;
    public float speed = 50.0f;

    public PlayerInput input;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        input = GetComponent<PlayerInput>();



        rb = GetComponent<Rigidbody>();



        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

    }

    // Update is called once per frame
    void Update()
    {



        //movement sysyem
        Vector3 tempMove = rb.linearVelocity;
        tempMove.x = inputY * speed;
        tempMove.z = inputX * speed;

        rb.linearVelocity = (tempMove.x * transform.forward) + (tempMove.y * transform.up) + (tempMove.z * transform.right);


    }

    public void Move(InputAction.CallbackContext context)
    {

        Vector2 InputAxis = context.ReadValue<Vector2>();
        inputX = InputAxis.x;
        inputY = InputAxis.y;

    }
}