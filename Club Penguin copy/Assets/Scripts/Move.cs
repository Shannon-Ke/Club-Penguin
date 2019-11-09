using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour {

	public GameObject[] waypoints;
	int count = 0;
	public float speed = 1f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
		if (GvrControllerInput.AppButtonDown) {
			float step =  speed * Time.deltaTime; // calculate distance to move
			//Vector3.MoveTowards(transform.position, waypoints[count % 3].transform.position, step);
			transform.position = waypoints[count % 3].transform.position;
			count++;
		}
		
	}
}
