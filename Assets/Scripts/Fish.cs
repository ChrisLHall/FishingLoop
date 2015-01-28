using UnityEngine;
using System.Collections;

public class Fish : MonoBehaviour {
	public float xSpeed;
	public float ySpeedMax;
	public float swimFreq;

	private int frameCount;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		frameCount++;
		float phase = frameCount / 60f * swimFreq * 2f * Mathf.PI;
		float xSpeedActual = xSpeed / 60f;
		float ySpeedActual = ySpeedMax / 60f * Mathf.Sin(phase);
		transform.position += new Vector3(xSpeedActual, ySpeedActual, 0f);
		transform.rotation = Quaternion.identity;
		transform.Rotate(new Vector3(0f, 0f, Mathf.Atan2(ySpeedActual, xSpeedActual) * 180f / Mathf.PI));

		if (Camera.main.WorldToScreenPoint(transform.position).x > Screen.width + 50f
		    	&& xSpeedActual > 0f) {
			// Assume the camera is centered at the origin and reflect across the X axis
			transform.position = new Vector3(-transform.position.x, transform.position.y,
			                                 transform.position.z);
		}
	}
}
