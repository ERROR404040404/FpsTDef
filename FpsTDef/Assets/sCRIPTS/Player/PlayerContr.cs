using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using static UnityEngine.Rendering.DebugUI;
using static UnityEngine.Rendering.DebugUI.Table;
using  System.Collections;

using JetBrains.Annotations;

using UnityEngine.Rendering;




public class PlayerContr : MonoBehaviour

{
    
    public int val = 0;
    public GameObject[] TowersPrefab;

    GameObject WeaponSlot;
    Ray jumpRay;

    TextMeshProUGUI bits;
    public int bitsAmount = 0;

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
    public bool canbuyTower = true;
    public bool canbuygun = false;
    public  bool isgunpicked = false;
    public bool spritning = false;

    public float cameraYMaxMin = 90;
    private RigidbodyConstraints constraints;

    public GameObject yes;


    public gunsquared gS; 


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        transform.localRotation = Quaternion.Euler(0, 0, 0);
        input = GetComponent<PlayerInput>();
        jumpRay = new Ray(transform.position, -transform.up);
        interactRay = new Ray(transform.position, transform.forward);

        bits = GameObject.FindGameObjectWithTag("bits").GetComponent<TextMeshProUGUI>();

        rb = GetComponent<Rigidbody>();
        playerCam = Camera.main;
        weaponSlot = transform.GetChild(0);


        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;


        GameObject yes = GameObject.Find("Melee slot");



        

    }

    // Update is called once per frame
    void Update()
    {
        
        if(GameObject.FindWithTag("gun") && isgunpicked)
        {
            canbuygun = false;
        }
        else if(bitsAmount >= 50)
        {
            canbuygun = true;
            
        }
            bits.text = "defcoin:" + bitsAmount;
        bitsAmount = Mathf.Clamp(bitsAmount, 0, int.MaxValue);
        
        
            if (Keyboard.current.digit1Key.wasPressedThisFrame && canSpawnTower && canbuyTower)
            {
                
                if (bitsAmount >= 50)
                { 
                    bitsAmount -= 50;
                    Instantiate(TowersPrefab[0], transform.position + transform.forward, transform.localRotation);
                 canSpawnTower = false;
                 StartCoroutine("TowerTimer");
                }


                
            }
            if (Keyboard.current.digit2Key.wasPressedThisFrame && canSpawnTower)
            {
                if (bitsAmount >= 100)
                {
                                    bitsAmount -= 100;   
                Instantiate(TowersPrefab[1], transform.position + transform.forward, transform.localRotation);
                canSpawnTower = false;
                StartCoroutine("TowerTimer");
                }

            }
            if (Keyboard.current.digit3Key.wasPressedThisFrame && canSpawnTower)
            {
                 if (bitsAmount >= 150)
                {
                    bitsAmount -= 150;
                    Instantiate(TowersPrefab[2], transform.position + transform.forward, transform.localRotation);
                    canSpawnTower = false;
                    StartCoroutine("TowerTimer");
                }
        }

        if (health <= 0)
        {
            StartCoroutine("Respawn");
            DropWeapon();

            yes.SetActive(true);

        }


       if (Keyboard.current.eKey.wasPressedThisFrame)
        {
             if (Physics.Raycast(interactRay, out interactHit, interactDistance) && canbuygun )
             {
                if (interactHit.collider.tag == ("gun"))
                {
                    pickUpObject = interactHit.collider.gameObject;
                    bitsAmount -= 50;
                    isgunpicked = true;
                }
             }
                else
                {
                    pickUpObject = null;
                }
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
                GameObject.Find("Melee slot").SetActive(false);

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
            isgunpicked = false;
            
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

            defcoin(10);
            Destroy(other.gameObject);

        }

        if (other.gameObject.CompareTag("enemy_hit"))
        {
            health -= 5;
        }
        if (other.gameObject.CompareTag("enemy_hit_follow"))
        {
            health -= 10;
        }

    }
 
    IEnumerator TowerTimer()
    {
        yield return new WaitForSeconds(towerCooldown);
        canSpawnTower = true;
    }
    public void defcoin(int amount)
    {
        bitsAmount += amount;

    }
    IEnumerator Respawn()
    {
        yield return new WaitForSeconds(3f);
        health = maxhealth;
    }
    public void sprinting(InputAction.CallbackContext context)
    {
        if (context.ReadValueAsButton())
        {
            speed = 20f;
            spritning = true;
        }
        else
        {
            speed = 10f;
            spritning = false;
        }
    }
}