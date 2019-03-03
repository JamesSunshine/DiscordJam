using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Experimental.PlayerLoop;
using Vector2 = UnityEngine.Vector2;


public class Enemy : MonoBehaviour
{
    public float speed = 6.0f;
    public Vector2 position => transform.position;


    private Rigidbody2D rb;
    private Vector2 direction;
    private GameObject player;

    private enum FlightMode {
        Circle, DiveBomb
    };

    private FlightMode flightMode;

    // Start is called before the first frame update
    void Start() {
        rb = GetComponent<Rigidbody2D>();

        direction = new Vector2(Random.Range(-1.0f, 1.0f), Random.Range(-1.0f, 1.0f)).normalized;
        rb.AddForce(direction * speed);

        flightMode = FlightMode.Circle;
        player = GameObject.Find("Gem");
    }

    // Update is called once per frame
    void FixedUpdate() {
        
        if (flightMode == FlightMode.Circle)
        {
            
            // Chance to switch to divebomb mode
            if (Random.Range(0.0f, 1.0f) < 0.05)
            {
                flightMode = FlightMode.DiveBomb;
            }
            
            UpdateFlightPitch();
        }
        else
        {
            UpdateFlightPitch();
            //UpdateDiveBombPitch();
        }
    }


    void UpdateDiveBombPitch()
    {
        
    }
    
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "projectile")
        {
            Destroy(collision.gameObject);
            Destroy(this.gameObject);
        }
    }

    void UpdateFlightPitch()
    {
        Vector2 correctionForce = FlightCorrectionForce(player.transform.position);
        rb.AddForce(correctionForce);

        rb.velocity = rb.velocity.normalized * speed;
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
