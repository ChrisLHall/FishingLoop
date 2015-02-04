using UnityEngine;
using System.Collections;

public class Fish : MonoBehaviour {
	public float xSpeed;
	public float ySpeedMax;
	public float swimFreq;

	public Sprite normalSprite;
	public Sprite caughtSprite;
	public Sprite deadSprite;

	private bool caught;
	private bool outOfWater;
	private int frameCount;
	private float ySpeed;

	private Hook theHook;
	private Manager manager;

	// Use this for initialization
	void Start () {
		frameCount = 0;
		caught = false;
		outOfWater = false;

		theHook = FindObjectOfType<Hook>();
		manager = FindObjectOfType<Manager>();

		manager.fishCount++;
	}
	
	// Update is called once per frame
	void Update () {
		frameCount++;

		float phase = frameCount / 60f * swimFreq * 2f * Mathf.PI;
		float xSpeedActual = xSpeed / 60f;
		float ySpeedActual = ySpeedMax / 60f * Mathf.Sin(phase);

		if (!caught && !outOfWater) {
			transform.position += new Vector3(xSpeedActual, ySpeedActual, 0f);
			transform.rotation = Quaternion.identity;
			transform.Rotate(new Vector3(0f, 0f, Mathf.Atan2(ySpeedActual, xSpeedActual) * 180f / Mathf.PI));
		} else if (!outOfWater) {
			Vector3 last = transform.position;
			transform.position = theHook.transform.position + Vector3.down * 0.6f;
			if (transform.position.y > manager.waterLevel + 0.5f) {
				outOfWater = true;
				manager.fishCount--;
				GetComponent<SpriteRenderer>().sprite = deadSprite;
				xSpeed = (theHook.transform.position.x - last.x) / 4f - 0.2f + Random.value * 0.4f;
				ySpeed = (theHook.transform.position.y - last.y) / 4f;
			}
		} else {
			transform.position += new Vector3(xSpeed, ySpeed, 0f);
			xSpeed *= 0.9f;
			// Gravity
			ySpeed -= 0.02f;
			if (transform.position.y < manager.waterLevel) {
				transform.position = new Vector3(transform.position.x, manager.waterLevel, 0f);
				ySpeed = 0f;
			}
		}

		if (Camera.main.WorldToScreenPoint(transform.position).x > Screen.width + 50f
		    	&& xSpeedActual > 0f) {
			// Assume the camera is centered at the origin and reflect across the X axis
			transform.position = new Vector3(-transform.position.x, transform.position.y,
			                                 transform.position.z);
		}

		if (!caught && !outOfWater && gameObject.renderer.bounds.Intersects(
				theHook.gameObject.renderer.bounds)) {
			caught = true;
			transform.rotation = Quaternion.identity;
			transform.Rotate(new Vector3(0f, 0f, Random.value * 360f));
			GetComponent<SpriteRenderer>().sprite = caughtSprite;
		}
	}
}
