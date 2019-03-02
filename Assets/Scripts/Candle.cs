using System;
using JetBrains.Annotations;
using UnityEngine;
using Utility;

public class Candle : UnityEngine.MonoBehaviour {
    public double range;
    public int damage;
    public int attackSpeed;
    
    //public Vector2 position => transform.position;
    public int health;
    public Brightness brightness;

    public Vector2 position {
        get { return transform.position; }
        
    }
    // Start is called before the first frame update
    void Start() {
        
    }

    // Update is called once per frame
    void Update() {
        
    }

    void OnHit(Enemy enemy) {
        health -= 1; //enemy.damage
        if (health <= 0) {
            Destroy(this);
        }
    }
    
    Enemy GetClosestEnemy(Enemy[] enemies) {
        Enemy closestEnemy = null;
        float closestDistanceSqr = Mathf.Infinity;
        Vector2 currentPosition = transform.position;
        foreach (Enemy enemy in enemies) {
            Vector2 directionToTarget = enemy.position - currentPosition;
            float dSqrToTarget = directionToTarget.sqrMagnitude;
            if (dSqrToTarget < closestDistanceSqr) {
                closestDistanceSqr = dSqrToTarget;
                closestEnemy = enemy;
            }
        }
     
        return closestEnemy;
    }
}
