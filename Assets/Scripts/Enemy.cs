using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Enemy : MonoBehaviour
{
    public float speed = 6.0f;

    private Rigidbody rb;

    // Start is called before the first frame update
    void Start() {

        rb = GetComponent<RigidBody>();

    }

    // Update is called once per frame
    void Update() {
        float moveHorizonal = Input.GetAxis("Horizonal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3 (moveHorizonal, 0.0f, moveVertical);

        rb.AddForce(movement * speed);
    }
}
