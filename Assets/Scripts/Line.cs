using UnityEngine;
using System.Collections;

public class Line : MonoBehaviour {
	// This is 96 pixels wide divided by 20 pixels per unit
	private float WIDTH_UNITS = 96f / 25f;

	private Hook hook;
	// Use this for initialization
	void Start () {
		hook = FindObjectOfType<Hook>();
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 pz = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		pz = new Vector3(pz.x, pz.y, 0f);
		transform.position = (pz + hook.transform.position) / 2f;
		transform.localScale = new Vector3((pz - hook.transform.position).magnitude / WIDTH_UNITS, 1f, 1f);
		float angle = Mathf.Atan2(hook.transform.position.y - pz.y,
		                          hook.transform.position.x - pz.x);
		transform.rotation = Quaternion.identity;
		transform.Rotate(new Vector3(0f, 0f, angle / Mathf.PI * 180f));
	}
}
