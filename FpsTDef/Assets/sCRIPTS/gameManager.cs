using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gameManager : MonoBehaviour
{
   
    TextMeshProUGUI bits;
    GameObject val;



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
        bits.text = "bits:" + val.GetComponent<vaule>().value;

    }

}

