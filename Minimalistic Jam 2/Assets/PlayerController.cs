using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour 
{
	[HideInInspector] public bool inputStroke	= false;
	[HideInInspector] public bool inputAim		= false;
	[HideInInspector] public bool inputFire		= false;
	[HideInInspector] public Vector2 axisInputDirection;
	public GameObject prefabPayload;

	void Update()
	{
		inputAim 	= Input.GetButton("Aim");
		inputFire	= Input.GetButtonUp("Aim");
		inputStroke	= Input.GetButtonDown("Stroke");

		axisInputDirection = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
		axisInputDirection.Normalize();
	}
}
