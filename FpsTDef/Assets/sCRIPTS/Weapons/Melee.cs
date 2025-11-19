using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.UI.Image;

public class Melee : MonoBehaviour
{
    public PlayerInput input;
    public Vector3 frw;
    public static bool queriesHitTriggers = true;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Attack(InputAction.CallbackContext context)
    {
        if (Physics.Raycast(transform.position, frw, 5))
        {
            print("stabby!");
        }
    }
}
