using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalColor : MonoBehaviour {

	// Use this for initialization
	void Start () {
		GetComponent<SkinnedMeshRenderer>().material = GameControl.control.mat;
	}

}
