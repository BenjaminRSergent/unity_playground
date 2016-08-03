using UnityEngine;
using System.Collections;
using DG.Tweening;

public class DotweenMove : MonoBehaviour {
	Sequence _sequence;
	public BezierCurve curve;

	float _pointAlong = 0;

	float PointAlong {
		set {
			_pointAlong = value;
			transform.position = curve.GetPoint (_pointAlong);
		}
	}
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.A)) {
			_sequence = DOTween.Sequence ();
			_sequence.Append(DOTween.To( () => transform.position, x => transform.position = x, new Vector3(2,2,2), 1 ));
			_sequence.Append(transform.DOShakeScale(2));
			_sequence.Append(transform.DORotate(new Vector3(0,180,0), 1));
			_sequence.Insert (_sequence.Duration() - 1, transform.DOMove(new Vector3(0,0,0), 1));
			_sequence.Insert(_sequence.Duration() - 1, DOTween.To( () => transform.position, x => transform.position = x, new Vector3(2,2,2), 1 ));
			_sequence.SetLoops (10);
		}


		if (Input.GetKeyDown (KeyCode.D)) {
			_pointAlong = 0;
			DOTween.To (() => _pointAlong, x => PointAlong = x, 1, 10);
			transform.DOShakeScale (10);
		}



	}

}
