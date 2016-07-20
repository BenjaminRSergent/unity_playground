using UnityEngine;
using System.Collections;
using UnityEngine.UI;

[System.Serializable]
public class RandomRange {
	public float min;
	public float max;

	public float Value {
		get {
			return Random.Range (min, max);
		}
	}
}
