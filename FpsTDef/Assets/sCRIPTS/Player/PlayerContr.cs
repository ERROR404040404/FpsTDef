using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using static UnityEngine.Rendering.DebugUI;
using static UnityEngine.Rendering.DebugUI.Table;
using  System.Collections;



public class PlayerContr : MonoBehaviour

{

    public GameObject[] TowersPrefab;

    GameObject WeaponSlot;
    Ray jumpRay;



    public float jumpDistatnce = 1.1f;
    public float jumpHieght = 10f;

    private Rigidbody rb;
    float inputX;
    float inputY;
    public float speed = 50.0f;
    Camera playerCam;
    Vector2 cameraRotation = new Vector2(-10, 0);

    public int health = 100;
    public int maxhealth = 100;

    Ray interactRay;
    RaycastHit interactHit;
    GameObject pickUpObject;
    public PlayerInput input;
    public Transform weaponSlot;
    public Weapon currentWeapon;
    public float interactDistance = 3f;
    public bool attacking = false;
    public float towerCooldown ;
    public bool canSpawnTower = true;


    public float cameraYMaxMin = 90;
    private RigidbodyConstraints constraints;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        input = GetComponent<PlayerInput>();
        jumpRay = new Ray(transform.position, -transform.up);
        interactRay = new Ray(transform.position, transform.forward);



        rb = GetComponent<Rigidbody>();
        playerCam = Camera.main;
        weaponSlot = transform.GetChild(0);


        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;



    }

    // Update is called once per frame
    void Update()
    {
            if (Keyboard.current.digit1Key.wasPressedThisFrame && canSpawnTower)
            {
                 Instantiate(TowersPrefab[0], transform.position + transform.forward, Quaternion.identity);
                 canSpawnTower = false;
                 StartCoroutine("TowerTimer");
            }
            if (Keyboard.current.digit2Key.wasPressedThisFrame && canSpawnTower)
            {
                Instantiate(TowersPrefab[1], transform.position + transform.forward, Quaternion.identity);
                canSpawnTower = false;
                StartCoroutine("TowerTimer");
            }
            if (Keyboard.current.digit3Key.wasPressedThisFrame && canSpawnTower)
            {
                Instantiate(TowersPrefab[2], transform.position + transform.forward, Quaternion.identity);
                canSpawnTower = false;
                StartCoroutine("TowerTimer");
            }

        if (health <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }



        if (Physics.Raycast(interactRay, out interactHit, interactDistance))
        {
            if (interactHit.collider.tag == ("gun"))
            {
                pickUpObject = interactHit.collider.gameObject;
            }
        }
        else
        {
            pickUpObject = null;
        }
        if (currentWeapon)

            if (currentWeapon.holdToAttack && attacking)
                currentWeapon.fire();



        Quaternion playerRotaion = Quaternion.identity;
        playerRotaion.y = playerCam.transform.rotation.y;
        playerRotaion.w = playerCam.transform.rotation.w;

        transform.rotation = playerRotaion;
        //movement sysyem
        Vector3 tempMove = rb.linearVelocity;
        tempMove.x = inputY * speed;
        tempMove.z = inputX * speed;

        rb.linearVelocity = (tempMove.x * transform.forward) + (tempMove.y * transform.up) + (tempMove.z * transform.right);
        cameraRotation.y = Mathf.Clamp(cameraRotation.y, -cameraYMaxMin, cameraYMaxMin);

        jumpRay.origin = transform.position;
        jumpRay.direction = -transform.up;

        interactRay.origin = playerCam.transform.position;
        interactRay.direction = playerCam.transform.forward;


    }
    public void Attack(InputAction.CallbackContext context)
    {
        if (currentWeapon)
        {
            if (currentWeapon.holdToAttack)
            {
                if (context.ReadValueAsButton())
                    attacking = true;
                else
                    attacking = false;
            }

            else if (context.ReadValueAsButton())
                currentWeapon.fire();
        }
    }
    public void Reload()
    {
        if (currentWeapon)
            if (!currentWeapon.reloading)
                currentWeapon.reload();
    }
    public void Interact()
    {
        if (pickUpObject)
        {
            if (pickUpObject.tag == "gun")
            {
                if (currentWeapon)
                    DropWeapon();

                pickUpObject.GetComponent<Weapon>().equip(this);
            }
            pickUpObject = null;
        }
        else
            Reload();
    }
    public void DropWeapon()
    {
        if (currentWeapon)
        {
            currentWeapon.GetComponent<Weapon>().unequip();
        }
    }
    public void Move(InputAction.CallbackContext context)
    {
        {
            Vector2 InputAxis = context.ReadValue<Vector2>();
            inputX = InputAxis.x;
            inputY = InputAxis.y;
        }
    }
    public void jump()
    {

        if (Physics.Raycast(jumpRay, jumpDistatnce))
        {
            rb.AddForce(transform.up * jumpHieght, ForceMode.Impulse);
        }


    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Usb"))
        {


            Destroy(other.gameObject);

        }
    }
 
    IEnumerator TowerTimer()
    {
        yield return new WaitForSeconds(towerCooldown);
        canSpawnTower = true;
    }
}