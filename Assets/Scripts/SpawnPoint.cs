using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    public GameObject ky;
    public GameObject ch;
    void Start()
    {
        
    }
    void Update()
    {
        if (ch.transform.position.x - transform.position.x > 55)
        {
            transform.position = new Vector3(ky.transform.position.x + 20, transform.position.y, 0);
            GameControl.instance.Spwn();
        }
    }
}
