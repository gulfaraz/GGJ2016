using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

public class InventoryManager : MonoBehaviour {

	public List<string> itemList;

	void Start () {
		itemList = new List<string>();
	}

	public void takeItem(string itemName) {
		itemList.Add (itemName);
	}

	public bool hasItem(string itemName) {
		return (itemList.IndexOf(itemName) >= 0);
	}
}
