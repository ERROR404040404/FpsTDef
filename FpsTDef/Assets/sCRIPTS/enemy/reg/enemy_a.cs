using UnityEngine;

public class enemy_a : MonoBehaviour
{
    public Enemy e;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {

        if (other.tag == "Knife")
        {
            e.health -= 50;
            Debug.Log("knif");
        }
        if (other.tag == "Bullet")
        {
            e.health -= 50;
        }
        if (other.tag == "Test_Tower_damage")
        {
            e.health -= 100;
        }
    }

    }
