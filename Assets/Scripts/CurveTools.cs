using UnityEngine;
using System.Collections;


public class CurveTools {
	public static Vector3 GetPointOnBezier (Vector3 start, Vector3 middleA, Vector3 middleB, Vector3 end, float percent) {
		float percentToUse = Mathf.Clamp01 (percent);
		float toEnd = 1 - percentToUse;

		Vector3 firstTerm = Mathf.Pow (toEnd, 3) * start;
		Vector3 secondTerm = 3 * Mathf.Pow (toEnd, 2) * percent * middleA;
		Vector3 thirdTerm = 3 * toEnd * Mathf.Pow (percent, 2) * middleB;
		Vector3 fourthTerm = Mathf.Pow (percent, 3) * end;

		return firstTerm + secondTerm + thirdTerm + fourthTerm;
	}
}


