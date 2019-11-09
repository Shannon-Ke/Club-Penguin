using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Firebase;
using Firebase.Database;
using Firebase.Unity.Editor;

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

	public DatabaseReference reference;

	public float speed = 20f;
	GameObject active;

	bool isDancing;
	// Use this for initialization
	void Start () {
		//com.theCookiePenguins.ClubPenguinVR
		FirebaseApp.DefaultInstance.SetEditorDatabaseUrl("https://clubpenguinvr-87ba4.firebaseio.com/");
        reference = FirebaseDatabase.DefaultInstance.RootReference;
		active = chest;
		isDancing = false;

		RetreiveData();
		// Debug.Log(data[0].datalist[0].x);
	}
	
	// Update is called once per frame
	void Update () {
		if (GvrControllerInput.AppButtonDown && !isDancing) {
			isDancing = true;
			//gen's code
		} else if (GvrControllerInput.AppButtonDown && isDancing) {
			isDancing = false;
			//stop dancing
		}

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

	List<DanceData> RetreiveData() {
		List<DanceData> list = new List<DanceData>();
		reference.Child("cvdata").GetValueAsync().ContinueWith(task => {
			if (task.IsFaulted) {
			// Handle the error...
			}
			else if (task.IsCompleted) {
			DataSnapshot snapshot = task.Result;
			//   Debug.Log(snapshot.Value.ToString());
			//   foreach (var x in snapshot.Children) {
			// 	  Debug.Log(x.Value.ToString());
			//   }
			
				foreach(var id in snapshot.Children) {
					foreach(var k in id.Children) {
						// var bodyIndex = 0;
						DanceData dd = new DanceData();
						foreach(var body in k.Children) {
							dd.addCoord(new Coord(body.Child("x").Value.ToString(), body.Child("y").Value.ToString(), body.Child("z").Value.ToString()));
							// var bodyIndex++;
						}
						list.Add(dd);
					}
				}
				Debug.Log(list[0].datalist[0].x);
			}
		});
	  return list;
	}
}

class DanceData {
	public List<Coord> datalist;
	public DanceData() {
		datalist = new List<Coord>();
	}
	public void addCoord(Coord c) {
		this.datalist.Add(c);
	}
}

class Coord {
	public string x;
	public string y;
	public string z;
	public Coord(string x, string y, string z) {
		this.x = x;
		this.y = y;
		this.z = z;
	}
}
