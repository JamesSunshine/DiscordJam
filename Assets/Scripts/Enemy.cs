using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Vector2 = UnityEngine.Vector2;


public class Enemy : MonoBehaviour
{
    public float speed = 6.0f;
    public Vector2 position => transform.position;



    // Start is called before the first frame update
    void Start() {
        //rb = GetComponent<RigidBody2D>();
    }

    // Update is called once per frame
    void Update() {
        //float moveHorizonal = Input.GetAxis("Horizonal");
        //float moveVertical = Input.GetAxis("Vertical");
    }
}
