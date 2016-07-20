using UnityEngine;
using System.Collections;

public class Stuff : MonoBehaviour {

	public Rigidbody Body {
		get;
		private set;
	}

	void Awake() {
		Body = GetComponent<Rigidbody> ();
	}
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}


	void OnTriggerEnter(Collider col) {
		if (col.tag == "Destroyer") {
			Destroy (gameObject);
		}
	}
}
