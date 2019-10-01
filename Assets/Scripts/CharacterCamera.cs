using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterCamera : MonoBehaviour
{
    private float x = 0.0f;
    private float y = 0.0f;
    public GameObject character;
    void Start()
    {
        x = transform.position.x - character.transform.position.x;
        y = transform.position.y;
    }
    void Update()
    {
        transform.position = new Vector3(x + character.transform.position.x, y, -10);
    }
}
