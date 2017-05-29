using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class Interactable : MonoBehaviour {

	// Needs to be public to pass between scripts, but doesn't need to be accessed in the editor. \\
	[HideInInspector]
	// The player's NavMesh. \\
	public NavMeshAgent playerAgent;

	// Stops interaction from continuing to fire. \\
	private bool hasInteracted;


	// Move towards clicked object and then stops before it. \\
	public virtual void MoveToInteraction(NavMeshAgent playerAgent) {

		hasInteracted = false;

		this.playerAgent = playerAgent;

		playerAgent.stoppingDistance = 3f;

		playerAgent.destination = transform.position;

	}

	void Update() {

		if (!hasInteracted && playerAgent != null && !playerAgent.pathPending) {

			if (playerAgent.remainingDistance <= playerAgent.stoppingDistance) {

				Interact ();

				hasInteracted = true;
			}
		}
	}

	public virtual void Interact(){

		Debug.Log ("Interacting with base class.");

	}

}
