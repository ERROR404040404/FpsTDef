using UnityEngine;

public class knifwe : MonoBehaviour
{
    public GameObject p;

    private void FixedUpdate()
    {
        transform.rotation = p.transform.rotation;
        transform.position = p.transform.position;
    }
}
