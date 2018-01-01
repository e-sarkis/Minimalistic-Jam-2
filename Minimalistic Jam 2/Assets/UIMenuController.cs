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

	public Color activeMenuElementColor;
	public Color inactiveMenuElementColor;

	private GameObject _optionCurrentSelection;

	// Used to determine staleness of Vertical axis input
	private bool _inputReturnedToZero = true;

	void Update()
	{
		if (!GameController.Instance.isGameOver) return;
		
		if (Mathf.Abs(Input.GetAxisRaw("Vertical")) > 0 && _inputReturnedToZero)
		{
			SwapActive();
		}
		_inputReturnedToZero = Input.GetAxisRaw("Vertical") == 0;
		if (Input.GetButtonDown("Select")) SelectOption();
	}

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
		// Set Current Selection
		_optionCurrentSelection = OptionRematchDisplayGameObject;
		OptionResetDisplayGameObject.GetComponent<Outline>().effectColor = inactiveMenuElementColor;
		_optionCurrentSelection.GetComponent<Outline>().effectColor = activeMenuElementColor;
	}

	public void HideMenu()
	{
		BlackoutDisplayGameObject.GetComponent<Image>().enabled = false;
		OptionRematchDisplayGameObject.GetComponent<Text>().enabled = false;
		OptionResetDisplayGameObject.GetComponent<Text>().enabled = false;
		// Activate and set Score Display Text
		Text ScoreDisplayText = ScoreDisplayGameObject.GetComponent<Text>();
		ScoreDisplayText.enabled = false;
		ScoreDisplayText.text = GameController.Instance.GetScoreText();
		// Activate Blackout
		BlackoutDisplayGameObject.GetComponent<Image>().enabled = false;
		// Set Current Selection
		_optionCurrentSelection = OptionRematchDisplayGameObject;
		OptionResetDisplayGameObject.GetComponent<Outline>().effectColor = inactiveMenuElementColor;
		_optionCurrentSelection.GetComponent<Outline>().effectColor = activeMenuElementColor;
	}

	void Awake()
	{
		// Singleton Initialization
        if (_instance != null && _instance != this) { Destroy(gameObject); }
		else { _instance = this; }
	}

	void SwapActive()
	{
		_optionCurrentSelection.GetComponent<Outline>().effectColor = inactiveMenuElementColor;
		if (_optionCurrentSelection == OptionRematchDisplayGameObject)
		{
			_optionCurrentSelection = OptionResetDisplayGameObject;
		} else
		{
			_optionCurrentSelection = OptionRematchDisplayGameObject;
		}
		_optionCurrentSelection.GetComponent<Outline>().effectColor = activeMenuElementColor;
	}

	void SelectOption()
	{
		HideMenu();
		if (_optionCurrentSelection == OptionRematchDisplayGameObject)
		{
			GameController.Instance.Rematch();
		}
		if (_optionCurrentSelection == OptionResetDisplayGameObject)
		{
			GameController.Instance.Reset();
		}
	}
}
