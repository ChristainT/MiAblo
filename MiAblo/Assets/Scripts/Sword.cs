using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Sword : MonoBehaviour, IWeapon {

	private Animator animator;

	public List<BaseStat> Stats { get; set; }


	void Start() {

		animator = GetComponent<Animator>();

	}


	public void PerformAttack() {

		animator.SetTrigger ("Base_Attack");
	}

	public void PerformSpecialAttack() {

		animator.SetTrigger ("Special_Attack");
	}


	void OnTriggerEnter(Collider collider) {

		if (collider.tag == "Enemy") {

			collider.GetComponent<IEnemy> ().TakeDamage (Stats[0].GetCalculatedStatValue());

		}

	}

}
