using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIMovement : MonoBehaviour {

	public GameObject player;

	public List<GameObject> WalkTos;


	public float alertDistance;
	public float attackingDistance;
	public float walkingDistance;

	private Vector3 direction;

	private Animator anim;

	private NavMeshAgent agent;



	// Use this for initialization
	void Start () {

		player = GameObject.FindGameObjectWithTag ("Player");

		agent = GetComponent<NavMeshAgent> ();
		
		anim = GetComponent<Animator> ();

		agent.enabled = false;

		anim.SetBool ("isIdle", true);
	}

	
	// Update is called once per frame
	void Update () {

		// Alert
		if (Vector3.Distance (player.transform.position, transform.position) < alertDistance && Vector3.Distance (player.transform.position, transform.position) > walkingDistance) {

			agent.enabled = false;

			anim.SetBool ("isAlert", true);

			anim.SetBool ("isIdle", false);

			anim.SetBool ("isAttacking", false);

			anim.SetBool ("isWalking", false);


		// Walking and Attacking
		} else if (Vector3.Distance (player.transform.position, transform.position) <= walkingDistance) {

			agent.enabled = true;

			agent.SetDestination (player.transform.position);


			anim.SetBool ("isWalking", true);

			anim.SetBool ("isAttacking", false);

			anim.SetBool ("isIdle", false);

			anim.SetBool ("isAlert", false);


			if (Vector3.Distance (player.transform.position, transform.position) <= attackingDistance) {

				anim.SetBool ("isAttacking", true);
				anim.SetBool ("isWalking", false);
			}


		// Idle
		} else if (anim.GetBool ("isIdle") == false && agent.enabled == false) {

			anim.SetBool ("isAttacking", false);

			anim.SetBool ("isAlert", false);

			anim.SetBool ("isIdle", true);

			anim.SetBool ("isWalking", false);


		}
	}
}
