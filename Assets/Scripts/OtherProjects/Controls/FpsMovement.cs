using UnityEngine;
using System.Collections;
using System.Collections.Generic;

// Moves the player on the x and z axises
public class FpsMovement : MonoBehaviour {
    public float walkSpeed = 30.0f;
	public float sprintSpeed = 50.0f;

	private PlayerMover _mover;
	private Camera _playerCamera;
	private Vector3 _groundInputMovementDirection;
	
	void Start () {
		_mover = GetComponent<PlayerMover> ();
		_playerCamera = GetComponentInChildren<Camera> ();
	}
	
	void FixedUpdate () {
		// Get the player's forward and right directions with verticality removed.
		// This is neccessary so the player doesn't fly when he looks up.
		Vector3 forwardWithoutY = _playerCamera.transform.forward;
		forwardWithoutY.y = 0;
		forwardWithoutY.Normalize ();

		Vector3 rightWithoutY = _playerCamera.transform.right;
		rightWithoutY.y = 0;
		rightWithoutY.Normalize ();

		// Set the desired movement direction based on player input and the forward/right directions.
		_groundInputMovementDirection = (forwardWithoutY * Input.GetAxis ("Vertical") + rightWithoutY * Input.GetAxis ("Horizontal")).normalized;
		_mover.AddMovement (walkSpeed * _groundInputMovementDirection * Time.deltaTime);
	}
}

