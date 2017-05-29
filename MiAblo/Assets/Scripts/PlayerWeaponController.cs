using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class PlayerWeaponController : MonoBehaviour {

	public GameObject playerHand;

	public GameObject EquipedWeapon	{ get; set; }

	CharacterStats characterStats;

	IWeapon equipedWeapon;


	void Start() {

		characterStats = GetComponent<CharacterStats> ();
	}


	public void EquipWeapon(Item itemToEquip) {

		if (EquipedWeapon != null) {

			characterStats.RemoveStatBonus (EquipedWeapon.GetComponent<IWeapon>().Stats);

			Destroy (playerHand.transform.GetChild(0).gameObject);

		}

		EquipedWeapon = (GameObject)Instantiate (Resources.Load<GameObject>("Weapons/" + itemToEquip.ObjectSlug), playerHand.transform.position, playerHand.transform.rotation);

		equipedWeapon = EquipedWeapon.GetComponent<IWeapon> ();

		equipedWeapon.Stats = itemToEquip.Stats;

		EquipedWeapon.transform.SetParent (playerHand.transform);

		characterStats.AddStatBonus (itemToEquip.Stats);

		Debug.Log (equipedWeapon.Stats[0]);
		
	}

	public void PerformWeaponAttack() {

		equipedWeapon.PerformAttack ();

	}

}
