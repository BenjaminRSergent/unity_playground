using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CoinCounter : MonoBehaviour {
	private Text _text;
	private ScoreTestGlobalState _state;
	// Use this for initialization
	void Start () {
		_text = GetComponentInChildren<Text> ();
		_state = GameObject.FindObjectOfType<ScoreTestGlobalState> ();
	}

	// Update is called once per frame
	void Update () {
		_text.text = "" + _state.Coins;
	}
}
