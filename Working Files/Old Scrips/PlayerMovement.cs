using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	[SerializeField]

	//Movement Speed
	float moveSpeed = 6f;

	//Upward and Downward Vector
	Vector3 forward, right;

	// Use this for initialization
	void Start () {

		//Forward vector = Camera forward vector
		forward = Camera.main.transform.forward;

		//Y value is always zero
		forward.y = 0;

		//Keep vector direction but set length to 1 or 0
		forward = Vector3.Normalize (forward);

		//Creates rotation for right vector
		right = Quaternion.Euler (new Vector3 (0, 90, 0)) * forward;
		
	}
	
	// Update is called once per frame
	void Update () {

		//Detect input and initiate movement
		if (Input.anyKey)
			Move();
		
	}

	void Move() {

		//New direction = value of x and y input
		Vector3 direction = new Vector3 (Input.GetAxis ("HorizontalKey"), 0, Input.GetAxis ("VerticalKey"));

		//Defines right/left movement amount/speed
		Vector3 rightMovement = right * moveSpeed * Time.deltaTime * Input.GetAxis ("HorizontalKey");

		//Defines up/down movement amount/speed
		Vector3 upMovement = forward * moveSpeed * Time.deltaTime * Input.GetAxis ("VerticalKey");

		//Total direction to move in
		Vector3 heading = Vector3.Normalize (rightMovement + upMovement);

		//Make rotation happen
		transform.forward = heading;

		//Make movement happen
		transform.position += rightMovement;
		transform.position += upMovement;
	}
		
}
