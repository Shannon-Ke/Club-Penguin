using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour {

	public Animator anim;
	public GameObject[] waypoints;
	int count = 0;
	public float speed = 5f;
	public bool isMoving;
	public GameObject camera;
	public Rigidbody rb;
	// Use this for initialization
	void Start () {
		isMoving = false;
		rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
		
		// if (GvrControllerInput.AppButtonDown) {
		// 	float step =  speed * Time.deltaTime; // calculate distance to move
		// 	//Vector3.MoveTowards(transform.position, waypoints[count % 3].transform.position, step);
		// 	transform.position = waypoints[count % 7].transform.position;
		// 	count++;
		// }
		if (GvrControllerInput.AppButtonDown && !isMoving) {
			isMoving = true;
			anim.SetBool("isWalking", true);
		} else if (GvrControllerInput.AppButtonDown && isMoving) {
			isMoving = false;
			anim.SetBool("isWalking", false);
		}
		if (isMoving) {
			rb.velocity = camera.transform.forward * speed;
		} else {
			rb.velocity = new Vector3(0f,0f,0f);
		}

		
	}
}
