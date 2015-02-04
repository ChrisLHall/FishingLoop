using UnityEngine;
using System.Collections;

public class Manager : MonoBehaviour {
	public float waterLevel = 2f;
	public int maxFishOnScreen = 20;
	public int fishCount = 0;
	public Rect spawnRect;

	public GameObject fishPrefab;

	private int fishSpawnCounter = 170;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		fishSpawnCounter--;
		if (fishSpawnCounter <= 0 && fishCount < maxFishOnScreen) {
			fishSpawnCounter = 40 + Mathf.RoundToInt(Random.value * 40f);
			GameObject newFish = (GameObject) Instantiate(fishPrefab);
			newFish.transform.position= new Vector3(
					spawnRect.xMin + Random.value * spawnRect.width,
		        	spawnRect.yMin + Random.value * spawnRect.height,
		            0f);
		}
	}
}
