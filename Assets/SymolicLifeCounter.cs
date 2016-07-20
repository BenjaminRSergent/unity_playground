using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;


public class SymolicLifeCounter : MonoBehaviour {
	public Image heartImage;

	private List<Image> _heartsShowing = new List<Image>();
	private RectTransform _trans;
	private ScoreTestGlobalState _state;

	private int NumHeartsShowing {
		get {
			return _heartsShowing.Count;
		}
	}
	// Use this for initialization
	void Start () {
		_state = GameObject.FindObjectOfType<ScoreTestGlobalState> ();
		_trans = GetComponent<RectTransform> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (_state.Lives < NumHeartsShowing) {
			RemoveHearts (NumHeartsShowing - _state.Lives);
		}
		if (_state.Lives > NumHeartsShowing) {
			AddHearts (_state.Lives - NumHeartsShowing);
		}
	}

	void RemoveHearts (int toRemove) {
		// To cheap to both pooling - look at the profiler.
		for (int index = 0; index < toRemove; index++) {
			Image img = _heartsShowing [_heartsShowing.Count - 1];
			_heartsShowing.Remove(_heartsShowing [_heartsShowing.Count - 1]);
			Destroy (img);
		}
	}

	void AddHearts (int toAdd) {
		for(int index = 0; index < toAdd; index++) {
			Image img = Instantiate (heartImage);

			img.rectTransform.SetParent(_trans);

			Vector3 position = new Vector3((NumHeartsShowing + 1) * heartImage.preferredWidth * heartImage.rectTransform.localScale.x, -heartImage.preferredHeight * heartImage.rectTransform.localScale.y, 0);

			img.rectTransform.anchoredPosition3D = position;
			_heartsShowing.Add (img);
		}
	}
}
