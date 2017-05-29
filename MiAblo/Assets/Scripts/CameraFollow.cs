using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

	// Define Player.
	public GameObject player;

	private bool MousePos;

	// Camera Position Information.
	public float offsetX = 0;
	public float offsetZ = 0;

	// Max distance from the player.
	public float maxDistance = 2;

	// Camera speed. Should be equal to player speed.
	public float playerVelocity = 10;

	private float movementX;
	private float movementZ;


	// Update is called once per frame
	void LateUpdate () {

		movementX = (player.transform.position.x + offsetX - this.transform.position.x) / maxDistance;

		movementZ = (player.transform.position.z + offsetZ - this.transform.position.z) / maxDistance;

		this.transform.position += new Vector3 ((movementX * playerVelocity * Time.deltaTime), 0, (movementZ * playerVelocity * Time.deltaTime));
		
	}
}
