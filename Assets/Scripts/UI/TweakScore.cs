using UnityEngine;
using System.Collections;

public class TweakScore : MonoBehaviour {
	public float increaseChance = 0.01f;
	public float decreaseChance = 0.01f;
	public float changeAmountMax = 10;
	private ScoreTestGlobalState _state;
	// Use this for initialization
	void Start () {
		_state = GameObject.FindObjectOfType<ScoreTestGlobalState> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Random.value < increaseChance) {
			_state.AddPoints((int)Random.Range(1, changeAmountMax+1));
		}
		if (Random.value < decreaseChance) {
			_state.RemovePoints((int)Random.Range(1, changeAmountMax+1));
		}
	}
}
