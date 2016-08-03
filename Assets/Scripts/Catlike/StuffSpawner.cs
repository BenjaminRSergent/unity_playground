using UnityEngine;
using System.Collections;

public class StuffSpawner : MonoBehaviour {
	public Stuff[] stuffPrefabs;

	public RandomRange randomVelocity;
	public RandomRange randomAngleVelocity;
	public RandomRange scale;
	public RandomRange stuffSpeed;
	public RandomRange betweenSpawn;
	public Material mat;

	private float tillSpawn = 0;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		tillSpawn -= Time.deltaTime;
		if (tillSpawn <= 0) {
			Spawn ();
		}
	}

	void Spawn () {
		Stuff stuff = stuffPrefabs[Random.Range(0, stuffPrefabs.Length)];
		Stuff newStuff = Instantiate<Stuff> (stuff);
		newStuff.transform.localPosition = transform.position;
		newStuff.Body.velocity = transform.up * stuffSpeed.Value + randomVelocity.Value * Random.onUnitSphere;
		newStuff.Body.angularVelocity = randomAngleVelocity.Value * Random.onUnitSphere;
		newStuff.transform.localScale = Vector3.one * scale.Value;
		newStuff.transform.rotation = Random.rotation;

		Renderer[] renderers = newStuff.GetComponentsInChildren<Renderer> ();

		foreach(Renderer renderer in renderers) {
			renderer.material = mat;
		}


		tillSpawn = betweenSpawn.Value;
	}
}
