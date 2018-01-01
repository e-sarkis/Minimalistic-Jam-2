using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OarAnimator : MonoBehaviour 
{
	public Sprite spriteOarsRest;
	public Sprite spriteOarsStroke;
	PlayerController playerController;

	private SpriteRenderer spriteRenderer;

	void Awake()
	{
		spriteRenderer = GetComponent<SpriteRenderer>();
		playerController = GetComponentInParent<PlayerController>();
	}

	void Update()
	{
		if (playerController.inputStroke && !playerController.inputAim)
		{
			spriteRenderer.sprite = spriteOarsStroke;
		}
		if (Input.GetButtonUp(playerController.GetJoyString() + "Stroke"))
		{	
			spriteRenderer.sprite = spriteOarsRest;
		}
	}

}
