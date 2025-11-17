using UnityEngine;
using static UnityEngine.UI.Image;

public class Melee : MonoBehaviour
{

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
       
    }

    void FixedUpdate()
    {
       Vector3 frw = transform.TransformDirection(Vector3.forward);

        if (Physics.Raycast(transform.position, frw, 5))
            print("Ahoy!");
    }

    

}
