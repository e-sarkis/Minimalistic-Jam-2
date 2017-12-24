using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour 
{
	bool inputStroke	= false;
	bool inputAim		= false;
	bool inputFire		= false;

	GameObject prefabPayload;

	void Update()
	{
		inputAim 	= Input.GetButton("Aim");
		inputFire	= Input.GetButtonUp("Aim");
		inputStroke	= Input.GetButtonDown("Stroke");
	}
}
