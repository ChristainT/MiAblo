using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class WorldInteraction : MonoBehaviour {

	[HideInInspector]
	public NavMeshAgent PlayerAgent;

	const int RIGHT_MOUSE_BUTTON = 1;


	void Awake() {

		PlayerAgent = GetComponent<NavMeshAgent>();

	}
		
	// Update is called once per frame
	void Update () {

		// Go to GetInteraction function.
		if (Input.GetMouseButtonDown (RIGHT_MOUSE_BUTTON) && !UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject()) {

			GetInteraction ();
		}
	}

	void GetInteraction(){

		// Creates a ray at the mouse position.
		Ray interactionRay = Camera.main.ScreenPointToRay (Input.mousePosition);

		RaycastHit interactionInfo;

		// Checks if ray intersects with plane and then sets target position to mouse position value.
		if (Physics.Raycast (interactionRay, out interactionInfo, Mathf.Infinity)) {
			
			GameObject interactedObject = interactionInfo.collider.gameObject;

			if (interactedObject.tag == "Interactable Object") {

				interactedObject.GetComponent<Interactable> ().MoveToInteraction (PlayerAgent);

			} else {

				PlayerAgent.stoppingDistance = 0;

				PlayerAgent.SetDestination (interactionInfo.point);

				DialogueSystem.Instance.dialoguePanel.SetActive (false);

			}

		}
	}
}
