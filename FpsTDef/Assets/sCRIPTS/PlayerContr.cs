
using UnityEngine;
using UnityEngine.InputSystem;



public class PlayerContr : MonoBehaviour


{


    private Rigidbody rb;
    float inputX;
    float inputY;
    public float speed = 50.0f;
    public float cSpeed = 5;
    public PlayerInput input;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        input = GetComponent<PlayerInput>();



        rb = GetComponent<Rigidbody>();



        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

    }
    float inputrX, inputrZ;
    // Update is called once per frame
    void Update()
    {
        //arrow look
        Quaternion rot = transform.rotation;
        rot.x = inputrX * cSpeed;
        rot.y = inputrX * cSpeed;

        rb.rotation = rot;

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
   public void Look(InputAction.CallbackContext context)
    {
        Vector2 InputAxis = context.ReadValue<Vector2>();

    }    
}

