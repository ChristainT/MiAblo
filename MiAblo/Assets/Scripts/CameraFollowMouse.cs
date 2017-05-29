using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowMouse : MonoBehaviour {

	public float edgePixels = 10;
	public float speed = 10;

	// Mouse move camera //
	// if (Input.mousePosition.x >= Screen.width - border)
	//    transform.position += transform.right * Time.deltaTime * speed


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void LateUpdate () {

		if (Input.mousePosition.x >= Screen.width - edgePixels) {
			transform.position += transform.right * Time.deltaTime * speed;
		} else if (Input.mousePosition.x <= 0 + edgePixels) {
			transform.position -= transform.right * Time.deltaTime * speed;
		} else if (Input.mousePosition.y >= Screen.height - edgePixels) {
			transform.position += transform.up * Time.deltaTime * speed;
		} else if (Input.mousePosition.y <= 0 + edgePixels) {
			transform.position -= transform.up * Time.deltaTime * speed;
		}
		
	}
}
