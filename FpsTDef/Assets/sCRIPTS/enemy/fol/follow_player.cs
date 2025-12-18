using UnityEngine;
using UnityEngine.AI;

public class follow_player : MonoBehaviour
{
    public  PlayerContr player;
    public float health = 100;
    public float maxHealth = 100;
    public GameObject[] drop;
    NavMeshAgent agent;
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.Find("Bombba") == true)
        {
            agent.destination = GameObject.Find("player").transform.position;

        }
        if (GameObject.Find("Bombba") == false)
        {
            gameObject.GetComponent<NavMeshAgent>().isStopped = true;
        }

        if (health == 0)
        {
            Destroy(gameObject);
            Instantiate(drop[Random.Range(0, drop.Length)], transform.position, Quaternion.identity);
        }

    }



    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.tag);
    }



    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Boom"))
        {
            Destroy(gameObject);
        }
        if (other.gameObject.CompareTag("Player"))
        {
           Destroy(gameObject);
            
        }

        Debug.Log(other.gameObject.tag);

    }

    

    }

