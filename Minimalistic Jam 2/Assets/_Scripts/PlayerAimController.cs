using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAimController : MonoBehaviour 
{
	public 	GameObject					aimReticle;
	private PlayerMovementController	moveController;
	private SpriteRenderer				reticleSpriteRenderer;
	private PlayerController			playerController;

	void Awake()
	{
		playerController				= GetComponent<PlayerController>();
		moveController					= GetComponent<PlayerMovementController>();
		reticleSpriteRenderer			= aimReticle.GetComponentInChildren<SpriteRenderer>();
		reticleSpriteRenderer.enabled	= false;
	}

	void Update ()
	{
		if (playerController.inputAim)
		{
			reticleSpriteRenderer.enabled = true; // Show Reticle
			float zRot = Mathf.Atan2(playerController.axisInputDirection.x, -playerController.axisInputDirection.y) * Mathf.Rad2Deg;
			if (playerController.axisInputDirection != Vector2.zero) // Is there actual axis input?
			{
				aimReticle.transform.rotation = Quaternion.Euler(new Vector3(0, 0, zRot - 90f));
			}
		} else { reticleSpriteRenderer.enabled = false; } // Hide Reticle
		
		if (playerController.inputFire && playerController.axisInputDirection != Vector2.zero)
		{
			FireProjectile();
		}
	}

	private void FireProjectile()
	{
	 	GameObject projectile = Instantiate(playerController.prefabPayload, transform.position, aimReticle.transform.rotation);
		ProjectileController projectileController = projectile.GetComponent<ProjectileController>();
		projectileController.shooter = this.gameObject;
		projectileController.direction = playerController.axisInputDirection;
		projectileController.Launch();
		playerController.timeSinceFiring = 0;
	}
}
