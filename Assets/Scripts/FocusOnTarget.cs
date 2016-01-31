using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class FocusOnTarget : MonoBehaviour {

	private Transform target;
	private bool enableFocus;
	private Text messageBox;
	private Text riddleBox;
	public string riddle;

	// Use this for initialization
	void Start () {
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
		}
	}
}
