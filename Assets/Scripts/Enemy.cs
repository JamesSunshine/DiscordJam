using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vector2 = UnityEngine.Vector2;


public class Enemy : MonoBehaviour
{
    public float speed = 6.0f;


    private Rigidbody2D rb;


    // Start is called before the first frame update
    void Start() {
        rb = GetComponent<Rigidbody2D>();
        rb.AddForce(new Vector2(2.0f, 0.0f));
    }

    // Update is called once per frame
    void Update() {
        //float moveHorizonal = Input.GetAxis("Horizonal");
        //float moveVertical = Input.GetAxis("Vertical");
    }

//    public Vector2 position => (Vector2) transform.position;
}
