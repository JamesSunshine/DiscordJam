using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vector2 = UnityEngine.Vector2;


public class Enemy : MonoBehaviour
{
    public float speed = 6.0f;
    public Vector2 position => transform.position;


    private Rigidbody2D rb;
    private Vector2 direction;

    // Start is called before the first frame update
    void Start() {
        rb = GetComponent<Rigidbody2D>();

        direction = new Vector2(Random.Range(-1.0f, 1.0f), Random.Range(-1.0f, 1.0f)).normalized;
        rb.AddForce(direction * speed);

    }

    // Update is called once per frame
    void Update()
    {
        Vector2 closestCandlePos = new Vector2(0.0f, 0.0f);

        float angleToCandle = Vector2.Angle(direction, closestCandlePos);
        
        
        Vector2 turnForce = Vector2.Perpendicular(rb.velocity) / rb.mass;

        if (angleToCandle > 36) {
            rb.AddTorque(0.2f);
        }

        if (angleToCandle < 34)
        {
            rb.AddTorque(-0.2f);
        }
    }
}
