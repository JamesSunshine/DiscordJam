using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {
	public float speed;

	public Vector2 direction { get; set; }
	public Vector2 position => transform.position;

	// Start is called before the first frame update
	void Start() {
		
	}

	// Update is called once per frame
	void FixedUpdate() {
		transform.Translate(speed * direction);
	}
}
