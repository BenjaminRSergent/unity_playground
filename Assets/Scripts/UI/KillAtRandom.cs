using UnityEngine;
using System.Collections;

public class KillAtRandom : MonoBehaviour {
	public float killChance = 0.01f;
	private ScoreTestGlobalState _state;
	// Use this for initialization
	void Start () {
		_state = GameObject.FindObjectOfType<ScoreTestGlobalState> ();
	}

	
	// Update is called once per frame
	void Update () {
		if (Random.value < killChance) {
			_state.RemoveLife ();
		}
	}
}
