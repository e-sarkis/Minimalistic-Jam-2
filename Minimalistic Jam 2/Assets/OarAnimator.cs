using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OarAnimator : MonoBehaviour 
{
	public Sprite spriteOarsRest;
	public Sprite spriteOarsStroke;

	private SpriteRenderer spriteRenderer;

	void Awake()
	{
		spriteRenderer = GetComponent<SpriteRenderer>();
	}

	void Update()
	{
		if (Input.GetButton("Stroke") && !Input.GetButton("Aim"))
		{
			spriteRenderer.sprite = spriteOarsStroke;
		}
		if (Input.GetButtonUp("Stroke"))
		{	
			spriteRenderer.sprite = spriteOarsRest;
		}
	}

}
