using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;

public class gunSwap: MonoBehaviour
{
    public int i = 0;
    private IEnumerator coroutine;


    //This Code Is Not Correct It Needs Fixy Wixy





    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (Keyboard.current.qKey.wasPressedThisFrame && (i == 0))
        {
            transform.localPosition = new Vector3(0.452f, 0.18f, 0.547f);
            transform.localRotation = Quaternion.Euler(0, 0, 0);

        }
        if (Keyboard.current.qKey.wasPressedThisFrame && (i == 1))
        {
            transform.localPosition = new Vector3(-(1 / 2), 0, -0.547f);
            transform.localRotation = Quaternion.Euler(-90, 0.18f, 0.547f);

        }
        coroutine = f(1f);
        StartCoroutine(coroutine);
    }
    private IEnumerator f(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);

        if (i == 1)
        {
            i -= 1;
        }

        else
        {
            i += 1;
        }
    }

}

