using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Consumable : MonoBehaviour {

	private Text messageBox;
	private InventoryManager inventoryManager;
	public string name;
	private bool access;

	// Use this for initialization
	void Start () {
		messageBox = GameObject.FindGameObjectWithTag ("Message").GetComponent<Text> ();
		inventoryManager = GameObject.FindGameObjectWithTag ("InventoryManager").GetComponent<InventoryManager> ();
	}
	
	// Update is called once per frame
	void Update () {
		if(access) {
			if (Input.GetKeyDown (KeyCode.F)) {
				inventoryManager.takeItem(name);
				messageBox.text = "";
				Destroy (gameObject);
			}
		}
	}

	void OnTriggerEnter(Collider other) {
		if(other.gameObject.tag == "Player") {
			access = true;
			messageBox.text = "Press F to take " + name;
		}
	}

	void OnTriggerExit(Collider other) {
		if(other.gameObject.tag == "Player") {
			access = false;
			messageBox.text = "";
		}
	}
}
