using Unity.VisualScripting;    
using UnityEngine;
using UnityEngine.AI;

public class enemy : MonoBehaviour
{  
    public float health = 100;
    public float maxHealth = 100;
    NavMeshAgent agent;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        agent.destination = GameObject.Find("Bombba").transform.position;

        if (health == 0)
        {
            Destroy(gameObject);
         
        }
    }
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Boom"))
        {
            Destroy(gameObject);
        }
    }
}
