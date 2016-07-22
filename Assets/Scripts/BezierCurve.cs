using UnityEngine;
using System.Collections;

public class BezierCurve : MonoBehaviour {
	public Vector3[] points;
	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}

	public Vector3 GetPoint(float percentAlong) {
		return transform.TransformPoint(CurveTools.GetPointOnBezier (points [0], points [1], points [2], points [3], percentAlong));
	}

	public void Reset() {
		points = new Vector3[] {
			new Vector3(1,1,1),	
			new Vector3(4,2,5),
			new Vector3(3,5,3),
			new Vector3(10,2,4)
		};
	}
}
