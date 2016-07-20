using UnityEngine;
using System.Collections;

public class TweakCoins : MonoBehaviour {
	public float increaseChance = 0.1f;
	public float decreaseChance = 0.025f;
	public float changeAmountMax = 50;
	private ScoreTestGlobalState _state;
	// Use this for initialization
	void Start () {
		_state = GameObject.FindObjectOfType<ScoreTestGlobalState> ();
	}

	// Update is called once per frame
	void Update () {
		if (Random.value < increaseChance) {
			_state.AddCoins((int)Random.Range(1, changeAmountMax));
		}
		if (Random.value < decreaseChance) {
			_state.RemoveCoins((int)Random.Range(1, changeAmountMax));
		}
	}
}
