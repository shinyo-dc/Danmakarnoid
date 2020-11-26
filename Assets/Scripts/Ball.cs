﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    // Config params
    [SerializeField] float startX = 16f;
    [SerializeField] float startY = 0f;
    [SerializeField] float velX = -15f;
    [SerializeField] float velY = 30f;
    // Start is called before the first frame update
    void Start()
    {
        Vector2 currPos;
        currPos.x = startX;
        currPos.y = startY;
        transform.position = currPos;
        LaunchOnStart();
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void LaunchOnStart()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(velX, velY);
    }
}
