using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Experimental.PlayerLoop;
using Vector2 = UnityEngine.Vector2;
using Vector3 = UnityEngine.Vector3;


public class Enemy : MonoBehaviour
{
    public float speed = 6.0f;
    public float chanceDiveBomb;
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
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        Vector2 correctionForce;
        
        if (flightMode == FlightMode.Circle)
        {
            float dt = 1f / 30f;
            
            // Chance to switch to divebomb mode
            if (Random.Range(0.0f, 1.0f) < chanceDiveBomb * dt)
            {
                flightMode = FlightMode.DiveBomb;
            }

            correctionForce = RelativePitchToTarget(player.transform.position, 37f);
        }
        else
        {
            correctionForce = RelativePitchToTarget(player.transform.position, 0f);
        }
        
        rb.AddForce(correctionForce);
        
        // Cap speed
        rb.velocity = rb.velocity.normalized * speed;
        
        // Set direction
        
        //transform.LookAt(getPosition() + rb.velocity * 0.1f);
    }


    
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "projectile")
        {
            Destroy(collision.gameObject);
            Destroy(this.gameObject);
        }
    }

    Vector2 getPosition()
    {
        Vector3 pos = transform.position;
        return new Vector2(pos.x, pos.y);
    }

    Vector2 CircleFlightCorrectionForce(Vector2 target)
    {


        return RelativePitchToTarget(target, 37f);
//        
//        Vector2 turnForce = Vector2.Perpendicular(rb.velocity) / rb.mass;
//        
//        float angleToTarget = Vector2.Angle(rb.velocity, target - getPosition());
//        
//        if (angleToTarget > 180) {
//            if (angleToTarget > (360 - 37))
//            {
//                return turnForce * -1;
//            }
//        }
//        else if (angleToTarget > 37)
//        {
//            return turnForce;
//        }
//        return Vector2.zero;
    }

    Vector2 DiveBombCorrectionForce(Vector2 target)
    {
        Vector2 turnForce = (target - getPosition()) * 5;
        float angleToTarget = Vector2.Angle(rb.velocity, target - getPosition());

        if (angleToTarget > 180)
        {
            if (angleToTarget > 359)
            {
                return turnForce * -1;
            }
        } else if (angleToTarget > 1)
        {
            return turnForce;
        }
        return Vector2.zero;
    }

    Vector2 RelativePitchToTarget(Vector2 target, float pitchDegrees, float deadRange = 5)
    {
        Vector2 turnForce = Vector2.Perpendicular(rb.velocity) / rb.mass;
        float angleToTarget = Vector2.Angle(rb.velocity, target - getPosition());

        float direction = 1;

        if (angleToTarget > 180)
        {
            angleToTarget = 360 - angleToTarget;
            direction = -1;
        }

        if (pitchDegrees - deadRange < angleToTarget || angleToTarget < pitchDegrees + deadRange)
        {
            return turnForce * direction;
        }
        else
        {
            return Vector2.zero;
        }
    }
}


