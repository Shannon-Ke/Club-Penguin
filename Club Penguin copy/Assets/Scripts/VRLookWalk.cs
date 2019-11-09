using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRLookWalk : MonoBehaviour {

	public Transform vrCamera;
	public Transform player;
	public float toggleAngle = 30f;
	public float speed = 3f;
	public bool moveForward;

	CharacterController cc;
	// Use this for initialization
	void Start () {
		cc = GetComponent<CharacterController>();
	}
	
	// Update is called once per frame
	void Update () {
		if (vrCamera.eulerAngles.x >= toggleAngle && vrCamera.eulerAngles.x < 90f) {
			moveForward = true;
		} else {
			moveForward = false;
		}
		if (moveForward) {
			Vector3 forward = transform.forward;

			cc.SimpleMove(forward * speed);
		}
	}
}
