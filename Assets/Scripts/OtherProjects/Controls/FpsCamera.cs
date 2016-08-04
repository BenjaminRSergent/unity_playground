using UnityEngine;
using System.Collections;

// The sticks the camera to the player's head position
public class FpsCamera : MonoBehaviour {
	public Transform playerHead;
	
	void Start () {
		Cursor.lockState = CursorLockMode.Locked;
	}
	
	
	void Update () {
		transform.position = playerHead.position;
		transform.rotation = playerHead.rotation;
	}
}
