using UnityEngine;
using System.Collections;

public class Sun : MonoBehaviour {
	public float sizeDelta;
	public float frequency;
	
	private int stepCounter;
	private Vector3 initialScale;
	
	// Use this for initialization
	void Start () {
		stepCounter = 0;
		initialScale = transform.localScale;
	}
	
	// Update is called once per frame
	void Update () {
		stepCounter++;
		float angle = (frequency * stepCounter / 60f) * 2 * Mathf.PI;
		float sizeMult = 1f + sizeDelta * Mathf.Cos(angle);
		transform.localScale = initialScale * sizeMult;
	}
}
