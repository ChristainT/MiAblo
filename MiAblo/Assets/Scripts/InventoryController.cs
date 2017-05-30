using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryController : MonoBehaviour {

	public PlayerWeaponController playerWeaponController;

	public Item sword;

	public Item staff;


	void Start() {

		playerWeaponController = GetComponent<PlayerWeaponController>();

		List<BaseStat> swordStats = new List<BaseStat> ();

		swordStats.Add (new BaseStat (6, "Power", "Your power level."));

		sword = new Item (swordStats, "Sword");

		staff = new Item (swordStats, "Staff");

	}

	void Update() {

		if (Input.GetKeyDown (KeyCode.V)) {

			playerWeaponController.EquipWeapon (sword);

		} else if (Input.GetKeyDown (KeyCode.B)) {

			playerWeaponController.EquipWeapon (staff);
		}

	}

}
