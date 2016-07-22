using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TextValueSetter : MonoBehaviour {

	public float TextValue {
		set {
			_text.text = value.ToString ("F2");
		}
	}

	private Text _text;

	// Use this for initialization
	void Start () {
		_text = GetComponent<Text> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

}
