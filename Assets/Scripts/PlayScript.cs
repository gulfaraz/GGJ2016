using UnityEngine;
using System.Collections;

public class PlayScript : MonoBehaviour {

	private float time;
	public bool quit;
	private GameObject playerLamp;
	private GameObject areaLight;

	// Use this for initialization
	void Start () {
		playerLamp = GameObject.FindGameObjectWithTag ("PlayerLamp");
		areaLight = GameObject.FindGameObjectWithTag ("AreaLight");

		playerLamp.GetComponent<Light>().enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (time >= 2.0f) {
			if (quit) {
				Application.Quit ();
			} else {
				StartCoroutine(EnableLight());
				StartCoroutine(KillAreaLight());
				gameObject.GetComponent<BoxCollider> ().enabled = false;
			}
		}
	}

	void OnTriggerStay(Collider other) {
		if(other.gameObject.tag == "Player") {
			time += Time.deltaTime;
		}
	}

	void OnTriggerExit(Collider other) {
		if(other.gameObject.tag == "Player") {
			time = 0.0f;
		}
	}

	IEnumerator EnableLight()
	{
		yield return new WaitForSeconds (4f);

		playerLamp.GetComponent<Light>().enabled = true;
	}

	IEnumerator KillAreaLight()
	{
		yield return new WaitForSeconds (0.7f);

		Destroy (areaLight);
	}
}
