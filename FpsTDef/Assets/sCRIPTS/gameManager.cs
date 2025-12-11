using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gameManager : MonoBehaviour
{
   public follow_player enemy;
    TextMeshProUGUI bits;
    GameObject val;
    TextMeshProUGUI wave;
    GameObject waveNumb;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (SceneManager.GetActiveScene().buildIndex == 1)
        {

            bits = GameObject.FindGameObjectWithTag("bits").GetComponent<TextMeshProUGUI>();
           
        }
    }
        // Update is called once per frame
        void Update()
        {
        //bits.text = "bits:" + val.GetComponent<vaule>().value;
        

    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("bullet"))
        {
            enemy.health -= 50;
        }
    }
}

