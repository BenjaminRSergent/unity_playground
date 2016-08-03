using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class FillBasedOnHealth : MonoBehaviour {
	private Image _healthBar;
	private ScoreTestGlobalState _state;
	// Use this for initialization
	void Start () {
		_state = GameObject.FindObjectOfType<ScoreTestGlobalState> ();
		_healthBar = GetComponent<Image> ();
	}
	
	// Update is called once per frame
	void Update () {
		_healthBar.fillAmount = _state.Health / (float)_state.maxHealth;
	}
}
