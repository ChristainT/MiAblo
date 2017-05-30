using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour {

	public Vector3 Direction { get; set; }

	public float Range { get; set; }

	public float Speed = 200;

	public int Damage { get; set; }

	Vector3 spawnPosition;


	void Start() {

		Range = 20f;

		Damage = 4;

		spawnPosition = transform.position;

		GetComponent<Rigidbody> ().AddForce (Direction * 500);

	}


	void Update() {

		if (Vector3.Distance (spawnPosition, transform.position) >= Range) {

			Extinguish ();
		}
			
	}

	void OnCollisionEnter(Collision collider){

		if (collider.transform.tag == "Enemy") {
			
			collider.transform.GetComponent<IEnemy> ().TakeDamage (Damage);
		}

		Extinguish ();
	}

	void Extinguish() {

		Destroy (gameObject);

	}

}
