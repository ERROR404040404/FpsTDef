
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.Windows;



public class PlayerContr : MonoBehaviour


{
    
    
    private Rigidbody rb;
    float inputX;
    float inputY;
    public float speed = 50.0f;
    public float cSpeed = 5;
    public PlayerInput input;
    public float weaponE;
    public Transform gunSlot;
    public Gun currentGun;
    public bool attacking = false;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        input = GetComponent<PlayerInput>();

        rb = GetComponent<Rigidbody>();

        

        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        playerCam = Camera.main;
        gunSlot = transform.Find("GunSlot");

    }
    Camera playerCam;
    Vector2 cameraRot = new Vector2(-10, 0);
    public float cameraYMaxMin = 90;

    // Update is called once per frame
    void Update()
    {
        //arrow look
        Quaternion playerRot = Quaternion.identity;
        playerRot.y = playerCam.transform.rotation.y;
        playerRot.w = playerCam.transform.rotation.w;

        transform.rotation = playerRot;

        cameraRot.y = Mathf.Clamp(cameraRot.y, -cameraYMaxMin, cameraYMaxMin);

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
    public void Attack(InputAction.CallbackContext context)
    {
        if (currentGun)
        {
            if (currentGun.holdAttack)
            {
                if (context.ReadValueAsButton())
                    attacking = true;
                else
                    attacking = false;
            }

            else if (context.ReadValueAsButton())
                currentGun.fire();
        }
    }
    public void Reload()
    {
        if (currentGun)
            if (!currentGun.relo)
                currentGun.reload();
    }
}

