using System;
using JetBrains.Annotations;
using UnityEngine;
using Utility;

public class Candle : UnityEngine.MonoBehaviour {
	public float range;
	public int damage;
	public float attacksPerSecond;
	public int health;
	public Brightness brightness;
	public GameObject[] gameObjects;
	private GameObject projectile => gameObjects[0];
	public Vector2 position => transform.position;

	private long _lastAttackTime = 0;
	private Enemy _enemy;
	private float _rangeSqr;

	// Start is called before the first frame update
	void Start() {
		_enemy = GameObject.Find("Enemy").GetComponent<Enemy>();
		_rangeSqr = range * range;
	}

	// Update is called once per frame
	void Update() {
		long time = DateTime.Now.Ticks;
		if (time - _lastAttackTime >= 10000000 / attacksPerSecond) {
			Console.WriteLine(time);
			_lastAttackTime = time;
			Enemy enemy = _enemy; //GetClosestEnemy(enemies); TODO
			if ((position - enemy.position).sqrMagnitude <= _rangeSqr) {
				Attack(enemy);
			}
		}
	}

	void Attack(Enemy enemy) {
		var startingPosition = position + new Vector2(0, 1.7f);
		Instantiate(projectile, startingPosition, Quaternion.identity)
			.GetComponent<Projectile>().direction = (enemy.position - startingPosition).normalized;
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
