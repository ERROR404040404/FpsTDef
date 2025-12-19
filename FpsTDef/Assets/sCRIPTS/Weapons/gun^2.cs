using System.Collections;
using UnityEngine;

public class gunsquared : Weapon
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (clip >= 0)
        {
            fill();

        }
    }
    IEnumerator fill()
    {
        yield return new WaitForSeconds(100);
        clip = clipSize;
    }
}
