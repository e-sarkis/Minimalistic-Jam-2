using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour 
{
	// Singleton
	private static GameController _instance;
    public static GameController Instance { get { return _instance; } }
	// Joystick Inputs
	public enum Joystick { Joy1, Joy2 };	// Can scale if Inputs exist in InputManager
	private Dictionary<Joystick, string> _joyEnumToJoyInputStrings; // e.x. "Joy1" in "Joy1Horizontal"
	// Game State Variables
	public enum PlayerNum { P1, P2 };
	public int totalInGamePlayers 	= 2;	// Total # Players In-Game, dead or alive
	private const int _maxPlayers 	= 2; 	// Max # Players that can play In-Game
	private const int _minPlayers 	= 2; 	// Min # Players required to play
	private Dictionary<int, int> _playerNumsToScores;
    public bool isGameOver = false;
	// Game Scene Features
	public List<GameObject> respawnLocations;

    private void Awake()
    {
		// Singleton Initialization
        if (_instance != null && _instance != this) { Destroy(gameObject); }
		else { _instance = this; }
		// Joystick Input Initialization
		_joyEnumToJoyInputStrings = new Dictionary<Joystick, string>();
		_joyEnumToJoyInputStrings.Add(Joystick.Joy1, "Joy1");
		_joyEnumToJoyInputStrings.Add(Joystick.Joy2, "Joy2");
		// Game State Variable Initialization
		Mathf.Clamp(totalInGamePlayers, _minPlayers, _maxPlayers);
		_playerNumsToScores = new Dictionary<int, int>();
		for (int i = 0; i < totalInGamePlayers; i++) _playerNumsToScores.Add(i, 0);
		DontDestroyOnLoad(transform.parent.transform.gameObject);
    }

	public string GetJoystickInputString(Joystick joy)
	{
		return _joyEnumToJoyInputStrings[joy];
	}

	public void Score(int playerNum)
	{
		_playerNumsToScores[playerNum]++;
		UIMenuController.Instance.ShowMenu();
		isGameOver = true;
	}

	public string GetScoreText()
    {
        string result = _playerNumsToScores[(int) PlayerNum.P1] + " - " + _playerNumsToScores[(int) PlayerNum.P2];
		return result;
    }

	public void Reset()
	{
		isGameOver = false;
		_playerNumsToScores[(int) PlayerNum.P1] = 0;
		_playerNumsToScores[(int) PlayerNum.P2] = 0;
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}

	public void Rematch()
	{
		isGameOver = false;
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}
}
