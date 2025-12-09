using UnityEngine;
using UnityEngine.AI;

public class follow_player : MonoBehaviour
{
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
        agent.destination = GameObject.Find("player").transform.position;
        if (health == 0)
        {
            Destroy(gameObject);
            Instantiate(drop[Random.Range(0, drop.Length)], transform.position, Quaternion.identity);
        }
        if (GameObject.Find("Bombba") == false)
        {
            gameObject.GetComponent<NavMeshAgent>().isStopped = true;
        }

    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
        }

        if (other.gameObject.CompareTag("Boom"))
        {
            Destroy(gameObject);
        }

    }

    private void OnTriggerEnter(Collider other)
    {
       
        if (other.tag == "Knife")
        {
            health -= 25;
        }
        if (other.tag == "Bullet")
        {
            health -= 50;
        }
        if (other.tag == "Test_Tower_damage")
        {
            health -= 100;
        }

    }



}
