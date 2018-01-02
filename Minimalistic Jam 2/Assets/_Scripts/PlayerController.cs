using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour 
{
	[HideInInspector] public bool inputStroke		= false;
	[HideInInspector] public bool inputStrokeHeld	= false;
	[HideInInspector] public bool inputAim			= false;
	[HideInInspector] public bool inputFire			= false;

	[HideInInspector] public Vector2 axisInputDirection;
	public GameObject prefabPayload;	// The Projectile the Player Fires
	public float fireCooldown;			// Time between firing and next aim
	[HideInInspector] public float timeSinceFiring;

	[HideInInspector] public string joyStr;
	public GameController.Joystick joy = GameController.Joystick.Joy1;
	public GameController.PlayerNum playerNum = GameController.PlayerNum.P1;

	void Start()
	{
		joyStr = GameController.Instance.GetJoystickInputString(joy);
	}

	void Update()
	{
		timeSinceFiring += Time.deltaTime;

		inputAim 		= Input.GetButton(joyStr + "Aim") && timeSinceFiring > fireCooldown;
		inputFire		= Input.GetButtonUp(joyStr + "Aim")  && timeSinceFiring > fireCooldown;
		inputStroke		= Input.GetButtonDown(joyStr + "Stroke");
		inputStrokeHeld = Input.GetButton(joyStr + "Stroke");

		axisInputDirection = new Vector2(Input.GetAxis(joyStr + "Horizontal"), Input.GetAxis(joyStr + "Vertical"));
		axisInputDirection.Normalize();
	}

	public string GetJoyString()
	{
		return GameController.Instance.GetJoystickInputString(joy);
	}
}
