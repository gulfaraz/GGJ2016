using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class FocusOnTarget : MonoBehaviour {

	private Transform target;
	private bool enableFocus;
	private Camera cameraGameObject;
	private Text messageBox;
	private Text riddleBox;
	public string riddle;

	// Use this for initialization
	void Start () {
		cameraGameObject = Camera.main;
		target = gameObject.GetComponentInChildren<Transform> ();
		messageBox = GameObject.FindGameObjectWithTag ("Message").GetComponent<Text> ();
		riddleBox = GameObject.FindGameObjectWithTag ("Riddle").GetComponent<Text> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (enableFocus) {
			riddleBox.text = "";
			messageBox.text = "Press F";
			if (Input.GetKey (KeyCode.F)) {
				riddleBox.text = riddle;
				messageBox.text = "";
				cameraGameObject.transform.LookAt (target);
				cameraGameObject.GetComponent<CameraFollow> ().focusTargetOn = true;
			} else if (Input.GetKeyUp (KeyCode.F)) {
				cameraGameObject.GetComponent<CameraFollow> ().focusTargetOn = false;
			}
		}
	}

	void OnTriggerEnter (Collider other) {
		if(other.gameObject.tag == "Player") {
			enableFocus = true;
			messageBox.text = "Press F";
		}
	}

	void OnTriggerExit (Collider other) {
		if(other.gameObject.tag == "Player") {
			enableFocus = false;
			messageBox.text = "";
			riddleBox.text = "";
			cameraGameObject.GetComponent<CameraFollow> ().focusTargetOn = false;
		}
	}
}
