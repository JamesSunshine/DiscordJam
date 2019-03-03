﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacter : MonoBehaviour
{
    public float speed = 0;
    public float health = 0;
    public float money = 0;
    public GameObject[] gameObjects;
    private GameObject candle => gameObjects[0];
    private GameObject candleLight => gameObjects[1];
    // Start is called before the first frame update

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector2 velocity = Vector2.zero;

        if (Input.GetKey(KeyCode.W))
        {
            velocity += Vector2.up;
        }
        if (Input.GetKey(KeyCode.S))
        {
            velocity += Vector2.down;
        }
        if (Input.GetKey(KeyCode.A))
        {
            velocity += Vector2.left;
        }
        if (Input.GetKey(KeyCode.D))
        {
            velocity += Vector2.right;
        }
        
        

        transform.Translate(velocity.normalized * speed * Time.deltaTime);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Vector3 position = transform.position;
            Instantiate(candle, position, Quaternion.identity);
        }
    }
}
