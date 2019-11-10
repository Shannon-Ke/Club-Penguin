using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class asdfaysdf : MonoBehaviour {
	public GameObject luarm;
	// Use this for initialization
	void Start () {
		Vector3 pos = luarm.transform.position;
		pos.x += 1.2f;
		luarm.transform.position = pos;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
