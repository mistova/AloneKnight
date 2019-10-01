using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatingFloor: MonoBehaviour
{
    private BoxCollider2D groundCollider;
    private float groundHorizontalLength = 0.0f;
    private float y;
    public float scale = 1.8f;
    public GameObject character, flr;
    private void Awake()
    {
        groundCollider = GetComponent<BoxCollider2D>();
        groundHorizontalLength = groundCollider.size.x;
        y = transform.position.y;
    }
    private void Update()
    {
        if (transform.position.x < character.transform.position.x - (groundHorizontalLength * scale))
            moveFlr();
        else if(transform.position.x > character.transform.position.x + (groundHorizontalLength * scale))
            moveFlr2();
    }

    private void moveFlr()
    {
        transform.position = new Vector2(groundHorizontalLength * scale + flr.transform.position.x, transform.position.y);
    }

    private void moveFlr2()
    {
        transform.position = new Vector2(flr.transform.position.x - (groundHorizontalLength * scale), transform.position.y);
    }
}