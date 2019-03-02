using System;
using UnityEngine;
using Utility;

public class Candle : UnityEngine.MonoBehaviour {
    public double range;
    public int damage;
    public int attackSpeed;
    public Vector2 position;
    public int health;
    public Brightness brightness;
    
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
    
//    Vector2 GetClosestEnemy(Enemy[] enemies) {
//        enemies[0].
//        Vector2 bestTarget;
//        float closestDistanceSqr = Mathf.Infinity;
//        Vector2 currentPosition = transform.position;
//        foreach (Vector2 potentialTarget in enemies) {
//            Vector3 directionToTarget = potentialTarget.position - currentPosition;
//            float dSqrToTarget = directionToTarget.sqrMagnitude;
//            if (dSqrToTarget < closestDistanceSqr) {
//                closestDistanceSqr = dSqrToTarget;
//                bestTarget = potentialTarget;
//            }
//        }
//     
//        return bestTarget;
//    }
}
