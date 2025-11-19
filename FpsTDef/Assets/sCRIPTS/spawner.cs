using UnityEngine;

public class spawner : MonoBehaviour
{
    public GameObject[] enemys;
    public bool isSpawning;
    public int spawnlimit;
    public int spawncount;
    public int waveNumb;
    


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        if (GameObject.FindWithTag("spawner") == true)
        {
            gameObject.SetActive(false);
            isSpawning = false;
        }
     
        if (GameObject.FindWithTag("spawner") == false)
        {
            isSpawning = true;
            gameObject.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {  
        
        spawncount = GameObject.FindGameObjectsWithTag("enemy").Length;

        if (spawncount >= spawnlimit)
        {
            isSpawning = false;

        }
        if (spawncount <= spawnlimit)
        {
            isSpawning = true;
            
        }
        if(GameObject.FindGameObjectsWithTag("enemy").Length == 0)
        {
            spawncount -= 0;
            waveNumb += 1;
            SpawnEnemyWave(waveNumb);
        }
    }
    void SpawnEnemyWave(int enemyToSpawn)
    {
        for (int i = 0; i < enemyToSpawn; i++)
        {
            Instantiate(enemys[Random.Range(0, enemys.Length)], transform.position, Quaternion.identity);
            spawncount += 1;
        }
    }
  
    
}
