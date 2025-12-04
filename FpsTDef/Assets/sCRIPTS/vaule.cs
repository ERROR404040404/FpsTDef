using TMPro;
using System.Collections;
using UnityEngine.UI;
using UnityEngine;


public class vaule : MonoBehaviour

{
  TextMeshProUGUI bits;
    public int value;
   

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
      bits = GameObject.FindGameObjectWithTag("bits").GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
      if (gameObject.tag == "Player")
        {
            value += 1;
         
        }
           bits.text = "bits: " + value;
      
    }

}
