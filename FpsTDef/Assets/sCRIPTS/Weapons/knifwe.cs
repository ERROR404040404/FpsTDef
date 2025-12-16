using UnityEngine;

public class knifwe : MonoBehaviour
{
    public Quaternion q = Quaternion.Euler(0, 0, 0);
   public Vector3 v = new Vector3(0, 0, 0);
   public GameObject p;
   public Quaternion w = Quaternion.Euler(0, 0, 0);

    void Start ()
    {
     p = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        w.x = p.transform.rotation.x - q.x;
        w.y = p.transform.rotation.y - q.y;
        w.z = p.transform.rotation.z - q.z;

        transform.position = p.transform.position;
        transform.rotation = w;

        print(w.x);
    }
}
