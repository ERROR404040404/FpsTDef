using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.UI.Image;

public class Melee : MonoBehaviour
{
    public PlayerInput input;
    public Vector3 frw;
    public static bool queriesHitTriggers = true;
    public float testVar;
    public float ifDamage;

    
    // Update is called once per frame
    void Update()
    {
        ifDamage = 0;
        var ray = new Ray(this.transform.position, this.transform.forward);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 5))
        {
             if (testVar == 1)
             {
                Debug.Log("Stabby!");
                ifDamage = 1;
             }
        }
    }

    public void Attack(InputAction.CallbackContext context)
    {       
        testVar = context.ReadValue<float>();
    }
}
