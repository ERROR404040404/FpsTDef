using Unity.VisualScripting;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    
    public bool enemyD = false;
    public float health = 100;
    public float maxHealth = 100;
    NavMeshAgent agent;
    public GameObject[] drop;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
        enemyD = false;
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.Find("Bombba") == true)
        {
            agent.destination = GameObject.Find("Bombba").transform.position;

        }
        if (GameObject.Find("Bombba")== false)
        {
            gameObject.GetComponent<NavMeshAgent>().isStopped = true;
        }

        if (health <= 0)
        {
            Destroy(gameObject);
            Instantiate(drop[Random.Range(0, drop.Length)], transform.position, Quaternion.identity);
        }
        
    }

        




    
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Boom"))
        {
            Destroy(gameObject);
        }
  


    }

    private void OnTriggerEnter(Collider other)
    {
      

    }

    


}
