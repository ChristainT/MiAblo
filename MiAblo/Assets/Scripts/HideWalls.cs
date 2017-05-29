using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideWalls : MonoBehaviour {

	public Transform player;

	public Transform cameraPos;

	public List<Transform> hiddenObjects;

	public LayerMask layerMask;


	// Use this for initialization
	void Start () {

		hiddenObjects = new List<Transform> ();

	}
	
	// Update is called once per frame
	void Update () {

		Vector3 direction = player.position - cameraPos.position;

		float distance = direction.magnitude;

		RaycastHit[] hits = Physics.RaycastAll (cameraPos.position, direction, distance, layerMask);

		for (int i = 0; i < hits.Length; i++) {

			Transform currentHit = hits [i].transform;

			if (!hiddenObjects.Contains (currentHit)) {

				hiddenObjects.Add (currentHit);
				//currentHit.GetComponent<Renderer>().enabled = false;
				Material mat = currentHit.GetComponent<Renderer>().material;
				Color C = mat.color;
				C.a = .5f;
				mat.color = C;

			}
		}

		for (int i = 0; i < hiddenObjects.Count; i++) {

			bool isHit = false;

			for (int j = 0; j < hits.Length; j++) {

				if (hits [j].transform == hiddenObjects [i]) {
					isHit = true;
					break;
				}
			}
			if (!isHit) {

				Transform wasHidden = hiddenObjects [i];
				//wasHidden.GetComponent<Renderer>().enabled = true;
				Material mat2 = wasHidden.GetComponent<Renderer>().material;
				Color D = mat2.color;
				D.a = 1f;
				mat2.color = D;
				hiddenObjects.RemoveAt (i);
				i--;
			}
		}

	}
}
