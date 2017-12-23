using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAimController : MonoBehaviour 
{
	public GameObject aimReticle;
	private PlayerMovementController moveController;
	private SpriteRenderer reticleSpriteRenderer;
	void Awake()
	{
		moveController = GetComponent<PlayerMovementController>();
		reticleSpriteRenderer = aimReticle.GetComponentInChildren<SpriteRenderer>();
		reticleSpriteRenderer.enabled = false;
	}

	// Update is called once per frame
	void Update () 
	{
		if (Input.GetButton("Aim"))
		{
			reticleSpriteRenderer.enabled = true;
			float zRot = Mathf.Atan2(moveController.axisInputDirection.x, -moveController.axisInputDirection.y) * Mathf.Rad2Deg;
			if (moveController.axisInputDirection != Vector2.zero) aimReticle.transform.rotation = Quaternion.Euler(new Vector3(0, 0, zRot - 90f));
		}
		if (Input.GetButtonUp("Aim")) reticleSpriteRenderer.enabled = false;
	}
}
