using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour 
{
	[HideInInspector] public bool inputStroke	= false;
	[HideInInspector] public bool inputAim		= false;
	[HideInInspector] public bool inputFire		= false;
	[HideInInspector] public Vector2 axisInputDirection;
	public GameObject prefabPayload;	// The Projectile the Player Fires
	[HideInInspector] public string joyStr;

	public GameController.Joystick joy = GameController.Joystick.Joy1;

	void Awake()
	{
		joyStr = GameController.Instance.GetJoystickInputString(joy);
	}

	void Update()
	{
		inputAim 	= Input.GetButton(joyStr + "Aim");
		inputFire	= Input.GetButtonUp(joyStr + "Aim");
		inputStroke	= Input.GetButtonDown(joyStr + "Stroke");

		axisInputDirection = new Vector2(Input.GetAxis(joyStr + "Horizontal"), Input.GetAxis(joyStr + "Vertical"));
		axisInputDirection.Normalize();
	}
}
