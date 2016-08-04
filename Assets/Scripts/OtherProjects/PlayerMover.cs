using UnityEngine;
using System.Collections;

// This script determines if the player is on the ground by raycasting from his feet.
// It also applies movement once per fixed updated based on requests from other scripts.
// If the player is grounded, it will also attempt to apply that movement to the ground.
public class PlayerMover : MonoBehaviour {
	private CharacterController _controller;

	// Movements related to general movement controls including jumping
	private Vector3 _nextInputMove = Vector3.zero;


	public CharacterController Controller {
		get {
			return _controller;
		}
	}
		
	void Start () {
		_controller = GetComponent<CharacterController> ();
	}


	void FixedUpdate() {
		_controller.Move (_nextInputMove);
		_nextInputMove.Set (0, 0, 0);
	}

	// Add a movement request to be applied on the next fixed update
	public void AddMovement(Vector3 movement) {
		_nextInputMove += movement;
	}
}
