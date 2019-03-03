using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Experimental.PlayerLoop;
using Vector2 = UnityEngine.Vector2;


public class Enemy : MonoBehaviour {
    public float speed = 6.0f;
    public Vector2 position => transform.position;


    private Rigidbody2D rb;
    private Vector2 direction;
    private GameObject player;

    // Start is called before the first frame update
    void Start() {
        rb = GetComponent<Rigidbody2D>();

        direction = new Vector2(Random.Range(-1.0f, 1.0f), Random.Range(-1.0f, 1.0f)).normalized;
        rb.AddForce(direction * speed);

        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void FixedUpdate() {
        UpdateFlightPitch();
    }

    void UpdateFlightPitch()
    {
        Vector2 correctionForce = FlightCorrectionForce(player.transform.position);
        rb.AddForce(correctionForce);
    }

    Vector2 getPosition()
    {
        Vector3 pos = transform.position;
        return new Vector2(pos.x, pos.y);
    }


    Vector2 FlightCorrectionForce(Vector2 target) {
        Vector2 turnForce = Vector2.Perpendicular(rb.velocity) / rb.mass;
        float angleToTarget = Vector2.Angle(rb.velocity, target - getPosition());
        
        if (angleToTarget > 180) {
            if (angleToTarget > (180 - 37))
            {
                return turnForce * -1;
            }
        }
        else if (angleToTarget > 37)
        {
            return turnForce;
        }
        return Vector2.zero;
    }
}
