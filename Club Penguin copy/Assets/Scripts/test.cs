using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour {

	public GameObject penguin;
	public Material mat;
	// Use this for initialization
	void Start () {
		penguin.GetComponent<SkinnedMeshRenderer>().material = (Material)(Resources.Load<Material>("Materials/brown.mat") as Material);
	}
	
	// Update is called once per frame
	void Update () {
		Debug.Log("IUAHDLIFUHASDF");
	}
}
