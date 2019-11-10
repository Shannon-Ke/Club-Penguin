using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Firebase;
using Firebase.Database;
using Firebase.Unity.Editor;

public class DanceController : MonoBehaviour {

	public float scale = 0.9f;

	public GameObject chest;
	public GameObject luarm;
	public GameObject llarm;
	public GameObject ruarm;
	public GameObject rlarm;
	public GameObject lfoot;
	public GameObject rfoot;

	public GameObject lshoulder;
	public GameObject rshoulder;

	public GameObject origin;

	public Transform chestTransform;
	public Transform luarmTransform;
	public Transform llarmTransform;
	public Transform ruarmTransform;
	public Transform rlarmTransform;
	public Transform lfootTransform;
	public Transform rfootTransform;

	public Transform lshoulderTransform;
	public Transform rshoulderTransform;
	public CanvasGroup rec;

	public DatabaseReference reference;

	public float speed = 20f;
	GameObject active;

	bool isDancing;
	bool isPlaying = false;
	List<DanceData> list;
	List<List<Vector3>> moves; 
	// Use this for initialization
	void Start () {
		//com.theCookiePenguins.ClubPenguinVR
		FirebaseApp.DefaultInstance.SetEditorDatabaseUrl("https://clubpenguinvr-87ba4.firebaseio.com/");
        reference = FirebaseDatabase.DefaultInstance.RootReference;
		active = chest;
		isDancing = false;
		
		RetreiveData();
		// Debug.Log(data[0].datalist[0].x);
		rec.alpha = 0f;
	}
	
	int count = 0;
	int index = 0;
	// Update is called once per frame
	void Update () {
		


		if (GvrControllerInput.AppButtonDown && !isDancing) {
			isDancing = true; 
			rec.alpha = 1f;
			//gen's code
			
		} else if (GvrControllerInput.AppButtonDown && isDancing) {
			isDancing = false;
			rec.alpha = 0f;
			//stop dancing

		}
		if (list != null && !isPlaying) {
			Debug.Log("formatting");
			FormatDance(list);
			
		} else if (list != null && isPlaying) {
			Debug.Log("done formatting");
			//play each frame
			//if done set list = null
			if (count > 40 && index < moves.Count) {
				//playing frame
				// SetPosition(moves[index]);
				List<Vector3> data = moves[index];
				chest.transform.position = data[0] * 0.75f + new Vector3(0f, -3f, 0f);
				luarm.transform.position = data[1] * 0.75f;
				lfoot.transform.position = data[2] * 0.95f + new Vector3(0f,5f,5f);
				llarm.transform.position = data[3] * 0.75f;
				//lshoulder.transform.position = data[3] + new Vector3(0f, -0.5f, 0f);
				//4
				ruarm.transform.position = data[5] * 0.75f;
				rfoot.transform.position = data[6] * 0.95f + new Vector3(0f,5f,5f);
				rlarm.transform.position = data[7] * 0.75f;
				//rshoulder.transform.position = data[7] + new Vector3(0f, -0.5f, 0f);;
				index++;
				count = 0;
			}
			count++;
			if (index == moves.Count) {
				count = 0;
					index = 0;
					list = null;
					ResetTransform();
					isPlaying = false;
				}
			
		}
	// 	if (Input.GetKeyDown(KeyCode.A)) {
	// 		active = chest;
	// 	} else if (Input.GetKeyDown(KeyCode.S)) {
	// 		active = luarm;
	// 	} else if (Input.GetKeyDown(KeyCode.D)) {
	// 		active = llarm;
	// 	} else if (Input.GetKeyDown(KeyCode.F)) {
	// 		active = ruarm;
	// 	} else if (Input.GetKeyDown(KeyCode.G)) {
	// 		active = rlarm;
	// 	} else if (Input.GetKeyDown(KeyCode.H)) {
	// 		active = lfoot;
	// 	} else if (Input.GetKeyDown(KeyCode.J)) {
	// 		active = rfoot;
	// 	}
	// 	Vector3 pos = active.transform.position;
	// 	if (Input.GetKey(KeyCode.LeftArrow)) {
	// 		pos.x -= speed * Time.deltaTime;
	// 	} else if (Input.GetKey(KeyCode.RightArrow)) {
	// 		pos.x += speed * Time.deltaTime;
	// 	} else if (Input.GetKeyDown(KeyCode.DownArrow)) {
	// 		pos.z -= speed * Time.deltaTime;
	// 	} else if (Input.GetKeyDown(KeyCode.UpArrow)) {
	// 		pos.z += speed * Time.deltaTime;
	// 	}

	// 	active.transform.position = pos;

	// 	if (Input.GetKeyDown(KeyCode.R)) {
	// 		ResetTransform();
	// 	}
	}

	void ResetTransform() {
		Debug.Log("resetting");
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

		// lshoulder.transform.position = lshoulderTransform.position;
		// lshoulder.transform.rotation = lshoulderTransform.rotation;

		// rshoulder.transform.position = rshoulderTransform.position;
		// rshoulder.transform.rotation = rshoulderTransform.rotation;
	}

	void SetPosition(List<Vector3> data) {
		Debug.Log("start " + luarm.transform.position);
		luarm.transform.position = data[0];
		lfoot.transform.position = data[1];
		llarm.transform.position = data[2];
		//4
		ruarm.transform.position = data[4];
		rfoot.transform.position = data[5];
		rlarm.transform.position = data[6];
		Debug.Log("transform " + data[0]);
		Debug.Log("end " + luarm.transform.position);
	}

	void FormatDance(List<DanceData> data) {
		moves = new List<List<Vector3>>();
		for (int i = 0; i < data.Count; i++) {
			moves.Add(new List<Vector3>());
			for (int j = 0; j < data[i].datalist.Count; j++) {
				Vector3 curr = data[i].datalist[j];
				float x = origin.transform.position.x + curr.x * scale;
				float y = origin.transform.position.y + curr.y * scale;
				float z = origin.transform.position.z + curr.z * scale;
				moves[i].Add(new Vector3(x,z,y));
				Debug.Log(x);
			}
		}
		isPlaying = true;
		
	}
	
	async void RetreiveData() {
		List<DanceData> templist = new List<DanceData>();
		
		await reference.Child("cvdata").GetValueAsync().ContinueWith(task => {
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
							float x = (float)double.Parse(body.Child("x").Value.ToString());
							float y = (float)double.Parse(body.Child("y").Value.ToString());
							float z = (float)double.Parse(body.Child("z").Value.ToString());

							dd.addCoord(new Vector3(x, y, z));
							// var bodyIndex++;
						}
						templist.Add(dd);
					}
				}
				list = templist;
			}
		});

		
	  //return list;
	}
}

class DanceData {
	public List<Vector3> datalist;
	public DanceData() {
		datalist = new List<Vector3>();
	}
	public void addCoord(Vector3 c) {
		this.datalist.Add(c);
	}
}

// class Coord {
// 	public string x;
// 	public string y;
// 	public string z;
// 	public Vector3 vector;
// 	public Coord(string x, string y, string z) {
// 		this.x = x;
// 		this.y = y;
// 		this.z = z;
// 	}
// }
