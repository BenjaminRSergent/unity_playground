using UnityEngine;
using System.Collections;

public class StuffRingSpawner : MonoBehaviour {
	public int numSpawners = 10;
	public float radius = 10;
	public float tilt = 30;
	public StuffSpawner spawner;
	public Material[] materials;

	void Awake() {
		for (int index = 0; index < numSpawners; index++) {
			CreateSpawner (index / (float)numSpawners);
		}
	}
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void CreateSpawner (float percent) {
		Transform rotater = new GameObject ("Rotator").transform;
		rotater.transform.SetParent (transform, false);
		rotater.localRotation = Quaternion.Euler (0, percent * 360, 0);

		StuffSpawner newSpawner = Instantiate<StuffSpawner> (spawner);
		newSpawner.transform.SetParent (rotater, false);
		newSpawner.transform.localPosition = new Vector3 (0, 0, radius);
		newSpawner.transform.localRotation = Quaternion.Euler (tilt, 0, 0);
		newSpawner.mat = materials[Random.Range(0, materials.Length)];
	}
}
