using System;
using UnityEngine;

// Rotates the current object's yaw(x axis) and pitch(y axis) based on mouse movements
public class MouseLook : MonoBehaviour
{
	public float mouseSensitivity = 100.0f;
	public float clampAngle = 80.0f;

	private float origRotY = 0.0f; // rotation around the up/y axis
	private float origRotX = 0.0f; // rotation around the right/x axis
	private float rotY = 0.0f; // rotation around the up/y axis
	private float rotX = 0.0f; // rotation around the right/x axis

	void Start () {
		Vector3 rot = transform.localRotation.eulerAngles;
		origRotY = rotY = rot.y;
		origRotX = rotX = rot.x;
	}

	void FixedUpdate () {
		float mouseX = Input.GetAxis("Mouse X");
		float mouseY = -Input.GetAxis("Mouse Y");

		rotY += mouseX * mouseSensitivity * Time.deltaTime;
		rotX += mouseY * mouseSensitivity * Time.deltaTime;

		rotX = Mathf.Clamp(rotX, -clampAngle, clampAngle);

		Quaternion localRotation = Quaternion.Euler(rotX, rotY, 0.0f);
		transform.rotation = localRotation;
	}
}