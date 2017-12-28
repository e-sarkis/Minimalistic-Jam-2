using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour 
{
	private static GameController _instance;
    public static GameController Instance { get { return _instance; } }

	// Joystick Inputs
	public enum Joystick { Joy1, Joy2, Joy3, Joy4 };
	private Dictionary<Joystick, string> _joyEnumToJoyInputStrings;

    private void Awake()
    {
		// Singleton Initialization
        if (_instance != null && _instance != this) { Destroy(this.gameObject); }
		else { _instance = this; }

		// Joystick Input Initialization
		_joyEnumToJoyInputStrings = new Dictionary<Joystick, string>();
		_joyEnumToJoyInputStrings.Add(Joystick.Joy1, "Joy1");
		_joyEnumToJoyInputStrings.Add(Joystick.Joy2, "Joy2");
    }

	public string GetJoystickInputString(Joystick joy)
	{
		return _joyEnumToJoyInputStrings[joy];
	}
}
