using UnityEngine;
using System.Collections;

public class TweakHealth : MonoBehaviour {
	public float increaseChance = 0.01f;
	public float decreaseChance = 0.03f;
	float changeAmountMax = 20;
	private ScoreTestGlobalState _state;
	// Use this for initialization
	void Start () {
		_state = GameObject.FindObjectOfType<ScoreTestGlobalState> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Random.value < increaseChance) {
			_state.Heal((int)Random.Range(1, changeAmountMax));
		}
		if (Random.value < decreaseChance) {
			_state.Damage((int)Random.Range(1, changeAmountMax));
		}
	}
}

