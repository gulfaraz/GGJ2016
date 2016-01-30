using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {

	public Transform target;
	public bool focusTargetOn;
	private float distance;
	private float height;
	private float damping;
	private bool smoothRotation;
	private float rotationDamping;

	// Use this for initialization
	void Start () {
		distance = 5.0f;
		height = 3.0f;
		damping = 5.0f;
		smoothRotation = true;
		rotationDamping = 10.0f;
	}
	
	// Update is called once per frame
	void Update () {
		if(!focusTargetOn) {
			var wantedPosition = target.TransformPoint(0, height, -distance);
			transform.position = Vector3.Lerp (transform.position, wantedPosition, Time.deltaTime * damping);

			if (smoothRotation) {
				var wantedRotation = Quaternion.LookRotation(target.position - transform.position, target.up);
				transform.rotation = Quaternion.Slerp (transform.rotation, wantedRotation, Time.deltaTime * rotationDamping);
			} else {
				transform.LookAt (target, target.up);
			}
		}
	}
}
