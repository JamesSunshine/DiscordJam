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
    private GameObject target;

    private enum FlightMode {
        Circle, DiveBomb, Fixated
    };

    private FlightMode flightMode;

    // Start is called before the first frame update
    void Start() {
        rb = GetComponent<Rigidbody2D>();

        direction = new Vector2(Random.Range(-1.0f, 1.0f), Random.Range(-1.0f, 1.0f)).normalized;
        rb.AddForce(direction * speed);

        flightMode = FlightMode.Circle;
        target = FindClosestEnemy();
        
        InvokeRepeating(nameof(ChanceChangeToDiveBomb), 5.0f, 1f);
        InvokeRepeating(nameof(ChangeTarget), 0.0f, 5.0f);
    }

    private void ChangeTarget()
    {
        target = FindClosestEnemy();
    }
    
    public GameObject FindClosestEnemy()
    {
        GameObject[] gos;
        gos = GameObject.FindGameObjectsWithTag("candle");
        GameObject closest = null;
        float distance = Mathf.Infinity;
        Vector3 position = transform.position;
        foreach (GameObject go in gos)
        {
            Vector3 diff = go.transform.position - position;
            float curDistance = diff.sqrMagnitude;
            if (curDistance < distance)
            {
                closest = go;
                distance = curDistance;
            }
        }
        return closest;
    }

    void ChanceChangeToDiveBomb()
    {
        if (flightMode != FlightMode.Circle)
            return;
        
        if (Random.Range(0.0f, 1.0f) < chanceDiveBomb)
        {
            flightMode = FlightMode.DiveBomb;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector2 correctionForce;
        
        if (flightMode == FlightMode.Circle)
        {
            correctionForce = RelativePitchToTarget(target.transform.position, 37f);
        }
        else if (flightMode == FlightMode.DiveBomb)
        {
            correctionForce = RelativePitchToTarget(target.transform.position, 0f);
            if (correctionForce == Vector2.zero)
            {
                flightMode = FlightMode.Fixated;
            }
        }
        else 
        {
            correctionForce = Vector2.zero;
            print("doing nothing...");
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

        if (pitchDegrees + deadRange < angleToTarget || angleToTarget < pitchDegrees - deadRange)
        {
            return turnForce * direction;
        }
        else
        {
            return Vector2.zero;
        }
    }
}


