using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacter : MonoBehaviour {
    public float speed = 0;
    public float health = 0;
    public float money = 0;
    public GameObject[] gameObjects;
    private GameObject candle => gameObjects[0];
    private GameObject candleLight => gameObjects[1];
    public Vector2 position => transform.position;

    void FixedUpdate()
    {
        Vector2 velocity = Vector2.zero;

        if (Input.GetKey(KeyCode.W)) {
            velocity += Vector2.up;
        }
        if (Input.GetKey(KeyCode.S)) {
            velocity += Vector2.down;
        }
        if (Input.GetKey(KeyCode.A)) {
            velocity += Vector2.left;
        }
        if (Input.GetKey(KeyCode.D)) {
            velocity += Vector2.right;
        }
        if (Input.GetKeyDown(KeyCode.E)) {
            Instantiate(candle, position, Quaternion.identity);
        }
        

        transform.Translate(velocity.normalized * speed * Time.deltaTime);
    }
}
