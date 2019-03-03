using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {
	public float speed;
    public GameObject DeadMoth;

	public Vector2 direction { get; set; }
	public Vector2 position => transform.position;

	// Start is called before the first frame update
	void Start() {
		
	}
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "enemy")
        {
            Destroy(other.gameObject);
            Destroy(this.gameObject);
            Instantiate(DeadMoth, position, Quaternion.identity);
        }
    }

    // Update is called once per frame
    void FixedUpdate() {
		transform.Translate(speed * direction);
	}
}
