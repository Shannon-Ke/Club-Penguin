using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DanceController : MonoBehaviour {

	public GameObject chest;
	public GameObject luarm;
	public GameObject llarm;
	public GameObject ruarm;
	public GameObject rlarm;
	public GameObject lfoot;
	public GameObject rfoot;

	public Transform chestTransform;
	public Transform luarmTransform;
	public Transform llarmTransform;
	public Transform ruarmTransform;
	public Transform rlarmTransform;
	public Transform lfootTransform;
	public Transform rfootTransform;

	public float speed = 20f;
	GameObject active;
	// Use this for initialization
	void Start () {
		active = chest;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.A)) {
			active = chest;
		} else if (Input.GetKeyDown(KeyCode.S)) {
			active = luarm;
		} else if (Input.GetKeyDown(KeyCode.D)) {
			active = llarm;
		} else if (Input.GetKeyDown(KeyCode.F)) {
			active = ruarm;
		} else if (Input.GetKeyDown(KeyCode.G)) {
			active = rlarm;
		} else if (Input.GetKeyDown(KeyCode.H)) {
			active = lfoot;
		} else if (Input.GetKeyDown(KeyCode.J)) {
			active = rfoot;
		}
		Vector3 pos = active.transform.position;
		if (Input.GetKey(KeyCode.LeftArrow)) {
			pos.x -= speed * Time.deltaTime;
		} else if (Input.GetKey(KeyCode.RightArrow)) {
			pos.x += speed * Time.deltaTime;
		} else if (Input.GetKeyDown(KeyCode.DownArrow)) {
			pos.z -= speed * Time.deltaTime;
		} else if (Input.GetKeyDown(KeyCode.UpArrow)) {
			pos.z += speed * Time.deltaTime;
		}

		active.transform.position = pos;

		if (Input.GetKeyDown(KeyCode.R)) {
			ResetTransform();
		}
	}

	void ResetTransform() {
		chest.transform.position = chestTransform.position;
		chest.transform.rotation = chestTransform.rotation;

		luarm.transform.position = luarmTransform.position;
		luarm.transform.rotation = luarmTransform.rotation;

		llarm.transform.position = llarmTransform.position;
		llarm.transform.rotation = llarmTransform.rotation;

		ruarm.transform.position = ruarmTransform.position;
		ruarm.transform.rotation = ruarmTransform.rotation;

		rlarm.transform.position = rlarmTransform.position;
		rlarm.transform.rotation = rlarmTransform.rotation;

		lfoot.transform.position = lfootTransform.position;
		lfoot.transform.rotation = lfootTransform.rotation;

		rfoot.transform.position = rfootTransform.position;
		rfoot.transform.rotation = rfootTransform.rotation;
	}
}
