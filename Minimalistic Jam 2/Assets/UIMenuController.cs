using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIMenuController : MonoBehaviour 
{
	// Singleton
	private static UIMenuController _instance;
    public static UIMenuController Instance { get { return _instance; } }

	public GameObject ScoreDisplayGameObject;
	public GameObject OptionRematchDisplayGameObject;
	public GameObject OptionResetDisplayGameObject;
	public GameObject BlackoutDisplayGameObject;

	private GameObject _optionCurrentSelection;

	public void ShowMenu()
	{
		BlackoutDisplayGameObject.GetComponent<Image>().enabled = true;
		OptionRematchDisplayGameObject.GetComponent<Text>().enabled = true;
		OptionResetDisplayGameObject.GetComponent<Text>().enabled = true;
		// Activate and set Score Display Text
		Text ScoreDisplayText = ScoreDisplayGameObject.GetComponent<Text>();
		ScoreDisplayText.enabled = true;
		ScoreDisplayText.text = GameController.Instance.GetScoreText();
		// Activate Blackout
		BlackoutDisplayGameObject.GetComponent<Image>().enabled = true;
	}

	void Awake()
	{
		// Singleton Initialization
        if (_instance != null && _instance != this) { Destroy(gameObject); }
		else { _instance = this; }
	}
}
