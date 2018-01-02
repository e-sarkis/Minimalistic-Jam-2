using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApplicationQuitter : MonoBehaviour 
{
	void Awake() { DontDestroyOnLoad(gameObject); }

	void Update () 
	{
		if (Input.GetButtonDown("Cancel"))
		{
			Application.Quit();
		}
	}
}
