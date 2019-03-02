using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacter : MonoBehaviour
{
    public float speed = 0;
    public float health = 0;
    public float money = 0;
    float diagonal = 0.7f;
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        Vector2 velocity = Vector2.zero;

        if (Input.GetKey(KeyCode.W))
        {
            velocity += Vector2.up;
        }
        if (Input.GetKey(KeyCode.S))
        {
            velocity += Vector2.down;
        }
        if (Input.GetKey(KeyCode.A))
        {
            velocity += Vector2.left;
        }
        if (Input.GetKey(KeyCode.D))
        {
            velocity += Vector2.right;
        }

        transform.Translate(velocity.normalized * speed * Time.deltaTime);
    }
}
