using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyBlue : Interactable, IEnemy {

	public float power;

	public float toughness;

	public float maxHealth;

	public float currentHealth;



	void Start() {

		currentHealth = maxHealth;

	}


	public void PerformAttack () {

	}

	public void TakeDamage (int amount) {

		currentHealth -= amount;

		if (currentHealth <= 0) {

			Die ();
		}

	}

	void Die(){

		Destroy (gameObject);

	}

}
