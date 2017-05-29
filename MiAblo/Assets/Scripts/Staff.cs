using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Staff : MonoBehaviour, IWeapon {

	public List<BaseStat> Stats { get; set; }


	public void PerformAttack() {

		Debug.Log ("Staff attack!");
	}
}
