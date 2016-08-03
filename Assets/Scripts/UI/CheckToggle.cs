using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CheckToggle : MonoBehaviour {
	private ToggleGroup _group;

	// Use this for initialization
	void Start () {
		_group = GetComponent<ToggleGroup> ();

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void LogChange(Toggle toggle) {
		Debug.Log("The toggle " + toggle.name + " is " + (toggle.isOn ? "On" : "Off"));
	}
}
