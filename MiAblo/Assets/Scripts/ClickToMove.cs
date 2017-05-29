using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[DisallowMultipleComponent]

[RequireComponent(typeof(NavMeshAgent))]

public class ClickToMove : MonoBehaviour {

	NavMeshAgent agent;

	// Where we want to move to.
	private Vector3 targetPosition;

	// Visual representation of right mouse button.
	const int RIGHT_MOUSE_BUTTON = 1;



	void Awake() {

		// Locate Navmesh reference and assign it for use.
		agent = GetComponent<NavMeshAgent> ();

	}

	// Begins on play
	void Start () {

		//Set target position to player.
		targetPosition = transform.position;
		
	}
	
	// Fires every frame
	void Update () {

		// Go to SetTargetPosition function.
		if (Input.GetMouseButton (RIGHT_MOUSE_BUTTON)) {
			SetTargetPosition ();
		}

		MovePlayer ();
	
	}

	// Sets the target position based off of the mouse position.
	void SetTargetPosition () {

		// Creates a plane stretching out from the player.
		Plane plane = new Plane (Vector3.up, transform.position);

		// Creates a ray at the mouse position.
		Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);

		// Stores the value of the mouse position.
		float point = 0f;

		// Checks if ray intersects with plane and then sets target position to mouse position value.
		if (plane.Raycast (ray, out point)) {
			targetPosition = ray.GetPoint (point);
		}
			
	}

	void MovePlayer() {

		this.agent.SetDestination (targetPosition);

		//Decorative line to show direction
		Debug.DrawLine (transform.position, targetPosition, Color.red);

	}
}
