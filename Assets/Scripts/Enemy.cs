using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vector2 = UnityEngine.Vector2;


public class Enemy : MonoBehaviour
{
    public float speed = 6.0f;


    private Rigidbody2D rb;
    private Vector2 direction;

    // Start is called before the first frame update
    void Start() {
        rb = GetComponent<Rigidbody2D>();

        direction = new Vector2(Random.Range(-1.0f, 1.0f), Random.Range(-1.0f, 1.0f)).normalized;
        rb.AddForce(initialDirection * speed);
    }

    // Update is called once per frame
    void Update()
    {
        Candle closestCandle = new Candle();

        if (Vector2.Angle(direction, closestCandle.position) > 36) {
            // pitch up
        }
        
        
    }

//    public Vector2 position => (Vector2) transform.position;
}
