using UnityEngine;
using UnityEditor;

[UnityEditor.CustomEditor(typeof(BezierCurve))]
public class BezierCurveInspector : UnityEditor.Editor {
	private const int _stepsToShow = 10;

	private BezierCurve _curve;

	private void OnSceneGUI() {
		_curve = target as BezierCurve;


		Quaternion rotation = (Tools.pivotRotation == PivotRotation.Local) ? _curve.transform.rotation : Quaternion.identity;
		Vector3 start = ShowPointHandles (0, rotation);	
		Vector3 middleA = ShowPointHandles (1, rotation);	
		Vector3 middleB = ShowPointHandles (2, rotation);	
		Vector3 end = ShowPointHandles (3, rotation);	;


		Handles.DrawBezier (start, end, middleA, middleB, Color.white, null, 2f);
	}

	void ManualDraw () {
		Vector3 start = _curve.GetPoint (0.0f);
		for (int step = 1; step < _stepsToShow; step++) {
			float percent = step / (float)(_stepsToShow - 1);
			Vector3 end = _curve.GetPoint (percent);
			Handles.DrawLine (start, end);
			start = end;
		}
	}

	Vector3 ShowPointHandles (int index, Quaternion rotation) {
		Vector3 position = _curve.transform.TransformPoint(_curve.points [index]);
		EditorGUI.BeginChangeCheck ();
		position = Handles.DoPositionHandle (position, rotation);
		if (EditorGUI.EndChangeCheck ()) {
			_curve.points [index] = _curve.transform.InverseTransformPoint (position);
		}
		return position;
	}
}
