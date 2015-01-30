using UnityEngine;
using System.Collections;

public class Hook : MonoBehaviour {
	/** The speed of the hook. This is effectively a 2d vector because Z is ignored. */
	Vector3 speed;
	float DISTANCE = 3.5f;
	float SPRINGINESS = 0.008f;
	Vector3 GRAVITY = new Vector3(0f, -0.005f, 0f);
	float DRAG = 0.04f;

	// Use this for initialization
	void Start () {
		speed = new Vector3();
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 pz = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		pz.z = 0;
		Vector3 diff = pz - transform.position;
		Vector3 force = new Vector3();
		force += GRAVITY;
		if (diff.magnitude > DISTANCE) {
			force += diff.normalized * SPRINGINESS * (diff.magnitude - DISTANCE);
		}
		force -= speed * DRAG;

		speed += force;
		transform.position += speed;

		transform.rotation = Quaternion.identity;
		transform.Rotate(new Vector3(0f, 0f, -speed.x * 60f));
	}
}
