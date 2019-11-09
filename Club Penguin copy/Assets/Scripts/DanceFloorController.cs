using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DanceFloorController : MonoBehaviour {

	public GameObject floor;
	public Material[] mats;

	int count = 0;


	
	// Update is called once per frame
	void Update () {
		if (count == 0) {
			foreach(Transform child in floor.transform) {
				int val = Random.Range(0, 5);
				
				child.gameObject.GetComponent<MeshRenderer>().material = mats[val];
			}
			count = 50;
		}
		count--;
	}
}
