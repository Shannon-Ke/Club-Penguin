using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PenguinColorController : MonoBehaviour {

	public GameObject penguin;
	public Material mat;
	

	public void SetColor() {
		penguin.GetComponent<SkinnedMeshRenderer>().material = mat;
		GameControl.control.mat = mat;
	}
}