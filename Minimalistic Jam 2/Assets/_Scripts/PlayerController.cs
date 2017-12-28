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

	// Temporary - Much to reside in GameController
	public enum Joystick { Joy1, Joy2, Joy3, Joy4 };
	private Dictionary<Joystick, string> joyNumToJoyInputStrings;

	public Joystick joy = Joystick.Joy1;

	void Awake()
	{
		// 	TEMP - Will exist in GameController
		joyNumToJoyInputStrings = new Dictionary<Joystick, string>();
		joyNumToJoyInputStrings.Add(Joystick.Joy1, "Joy1");
		joyNumToJoyInputStrings.Add(Joystick.Joy2, "Joy2");

		joyStr = joyNumToJoyInputStrings[joy];
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
