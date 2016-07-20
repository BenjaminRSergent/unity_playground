using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreCounter : MonoBehaviour {
	private Text _text;
	private ScoreTestGlobalState _state;
	// Use this for initialization
	void Start () {
		_text = GetComponent<Text> ();
		_state = GameObject.FindObjectOfType<ScoreTestGlobalState> ();
	}

	// Update is called once per frame
	void Update () {
		_text.text = "<b><color=Blue>Score</color></b> " + _state.Score;
	}
}
