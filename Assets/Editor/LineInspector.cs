using UnityEngine;
using UnityEditor;

[UnityEditor.CustomEditor(typeof(Line))]
public class LineInspector : UnityEditor.Editor {

	private void OnSceneGUI() {
		Line line = target as Line;
		Handles.color = Color.white;
		Transform trans = line.transform;
		Vector3 start = trans.TransformPoint (line.start);
		Vector3 end = trans.TransformPoint (line.end);
		Handles.DrawLine(start,end);

		Quaternion handleRotation = (Tools.pivotRotation == PivotRotation.Local) ?
			trans.rotation : Quaternion.identity;

		EditorGUI.BeginChangeCheck ();
		start = Handles.DoPositionHandle(start, handleRotation);
		if (EditorGUI.EndChangeCheck ()) {
			Undo.RecordObject(line, "Move Point");
			EditorUtility.SetDirty(line);
			line.start = trans.InverseTransformPoint (start);
		}
		EditorGUI.BeginChangeCheck ();
		end = Handles.DoPositionHandle(end, handleRotation);
		if (EditorGUI.EndChangeCheck ()) {
			Undo.RecordObject(line, "Move Point");
			EditorUtility.SetDirty(line);
			line.end = trans.InverseTransformPoint (end);
		}

	}
}
