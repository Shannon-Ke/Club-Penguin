using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PenguinColorController : MonoBehaviour {

	public GameObject penguin;
	
	void Start() {
		GetComponent<Button>().onClick.AddListener(SetColor);
	}
	
	public void SetColor() {
		GetComponent<MeshRenderer>().material = Resources.Load<Material>("Materials/" + gameObject.name + ".mat");
	}
}
