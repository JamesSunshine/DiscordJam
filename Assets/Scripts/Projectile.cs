using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {
	public float speed;
	public GameObject DeadMoth;
	private long _start;

	public Vector2 direction { get; set; }
	public Vector2 position => transform.position;

	void Start() {
		_start = DateTime.Now.Ticks;
	}
	
	private void OnTriggerEnter2D(Collider2D other) {
		if (!other.CompareTag("enemy")) return;

		Destroy(other.gameObject);
		Destroy(this.gameObject);
		Instantiate(DeadMoth, position, Quaternion.identity);
	}

	// Update is called once per frame
	void FixedUpdate() {
		if (DateTime.Now.Ticks - _start > 10 * 1000000) {
			Destroy(this.gameObject);
		} else {
			transform.Translate(speed * direction);
		}
	}
}
