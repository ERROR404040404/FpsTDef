using UnityEngine;

public class follow_player_a : MonoBehaviour
{
    public follow_player fP;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.tag);

        if (other.tag == "Knife")
        {
            fP.health -= 150;
            Debug.Log("knif");
        }
        if (other.tag == "Bullet")
        {
            fP.health -= 50;
        }
        if (other.tag == "Test_Tower_damage")
        {
            fP.health -= 100;
        }
    }
}
