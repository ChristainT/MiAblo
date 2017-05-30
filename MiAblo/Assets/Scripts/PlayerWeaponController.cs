using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class PlayerWeaponController : MonoBehaviour {

	public GameObject playerHand;

	public GameObject EquipedWeapon	{ get; set; }

	Transform spawnProjectile;

	CharacterStats characterStats;

	IWeapon equipedWeapon;

	const int LEFT_MOUSE_BUTTON = 0;


	void Start() {

		spawnProjectile = transform.FindChild ("ProjectileSpawn");

		characterStats = GetComponent<CharacterStats> ();
	}

	void Update() {

		if (Input.GetMouseButtonDown (LEFT_MOUSE_BUTTON) && !UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject()) {

			PerformWeaponAttack ();
		}
		if (Input.GetKeyDown (KeyCode.Z))
			PerformWeaponSpecialAttack ();

	}


	public void EquipWeapon(Item itemToEquip) {

		if (EquipedWeapon != null) {

			characterStats.RemoveStatBonus (EquipedWeapon.GetComponent<IWeapon>().Stats);

			Destroy (playerHand.transform.GetChild(0).gameObject);

		}


		EquipedWeapon = (GameObject)Instantiate (Resources.Load<GameObject>("Weapons/" + itemToEquip.ObjectSlug), playerHand.transform.position, playerHand.transform.rotation);

		equipedWeapon = EquipedWeapon.GetComponent<IWeapon> ();

		if (EquipedWeapon.GetComponent<IProjectileWeapon> () != null) {

			EquipedWeapon.GetComponent<IProjectileWeapon> ().ProjectileSpawn = spawnProjectile;
		}

		equipedWeapon.Stats = itemToEquip.Stats;

		EquipedWeapon.transform.SetParent (playerHand.transform);

		characterStats.AddStatBonus (itemToEquip.Stats);

		//Debug.Log (equipedWeapon.Stats[0]);
	}


	public void PerformWeaponAttack() {

		equipedWeapon.PerformAttack ();

	}

	public void PerformWeaponSpecialAttack() {

		equipedWeapon.PerformSpecialAttack ();

	}
}
