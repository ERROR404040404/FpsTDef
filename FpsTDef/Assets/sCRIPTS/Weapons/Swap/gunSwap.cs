using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;
using UnityEngine.PlayerLoop;

public class gunSwap: MonoBehaviour
{
    public int i = 0;
    private IEnumerator coroutine;
    public meleeSwap mS;

    //This Code Is Not Correct It Needs Fixy Wixy





  

    // Update is called once per frame
    void Update()
    {
        if (transform.childCount == 1)
        {
            if (!mS.isKnifeOut)
            {
                transform.localPosition = new Vector3(0.452f, 0.18f, 0.547f);
                transform.localRotation = Quaternion.Euler(0, 0, 0);

            }
            if (mS.isKnifeOut)
            {
                transform.localPosition = new Vector3(-(1 / 2), 0, -0.547f);
                transform.localRotation = Quaternion.Euler(-90, 0, 0);

            }
        }
    }
 
}

