using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour {


	public void LoadMain() {
		SceneManager.LoadScene("ClubPenguin");
	}

	public void LoadMine() {
		SceneManager.LoadScene("MineCart");
	}

	public void LoadClub() {
		SceneManager.LoadScene("Club");
	}
}
