using UnityEngine;
using System.Collections;

public class Water : MonoBehaviour {
	public float circleWidth;
	public float circleHeight;
	public float frequency;
	public float phase;

	private int stepCounter;
	private Vector3 initialPos;

	// Use this for initialization
	void Start () {
		stepCounter = 0;
		initialPos = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		stepCounter++;
		float angle = (phase + frequency * stepCounter / 60f) * 2 * Mathf.PI;
		float xOffset = circleWidth * Mathf.Cos(angle);
		float yOffset = circleHeight * Mathf.Sin(angle);
		transform.position = initialPos + new Vector3(xOffset, yOffset, 0f);
	}
}
