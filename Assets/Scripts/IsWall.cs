using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsWall : MonoBehaviour
{   
    GameObject player;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }
    void Update()
    {

    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject == player)
        {
            GameControl.instance.isWallTrue();
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject == player)
        {
            GameControl.instance.isWallFalse();
        }
    }
}
