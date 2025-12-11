using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class spawner : MonoBehaviour
{

    public GameObject[] enemys;
    public Transform[] spawns;
    public bool isSpawning;
    public int spawnlimit;
    public int spawncount;
    public int waveNumb;
    TextMeshProUGUI wave;
   



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        

        wave = GameObject.FindGameObjectWithTag("wave").GetComponent<TextMeshProUGUI>();

        spawncount = GameObject.FindGameObjectsWithTag("enemy").Length;

        if (spawncount >= spawnlimit)
        {
            isSpawning = false;

        }
        if (spawncount <= spawnlimit)
        {
            isSpawning = true;
            
        }
        if (GameObject.FindGameObjectsWithTag("enemy").Length == 0 && GameObject.FindGameObjectsWithTag("follow").Length == 0)
        {
            spawncount -= 0;
            waveNumb += 1;
            SpawnEnemyWave(waveNumb);
            wave.text = "wave: " + waveNumb;
            

        }



    }
    void SpawnEnemyWave(int enemyToSpawn)
    {
        List<Transform> spawnPoints = new List<Transform>(spawns);
        for (int i = 0; i < enemyToSpawn; i++)
        {
            if (spawnPoints.Count == 0)
            {
                spawnPoints = new List<Transform>(spawns);
            }
            int index = Random.Range(0, spawnPoints.Count);
            Transform spawnPoint = spawnPoints[index];
            GameObject en = Instantiate(enemys[Random.Range(0, enemys.Length)], spawnPoint.position, Quaternion.identity);
     

            spawncount += 1;
        }
    }
}
