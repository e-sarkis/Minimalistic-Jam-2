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
			reticleSpriteRenderer.enabled = true;
			float zRot = Mathf.Atan2(playerController.axisInputDirection.x, -playerController.axisInputDirection.y) * Mathf.Rad2Deg;
			if (playerController.axisInputDirection != Vector2.zero)
			{
				aimReticle.transform.rotation = Quaternion.Euler(new Vector3(0, 0, zRot - 90f));
			}
		}
		if (playerController.inputFire)
		{
			reticleSpriteRenderer.enabled = false;
			//FireProjectile();
		}
	}

	// private void FireProjectile()
	// {
	// 	GameObject projectile = Instantiate(playerController.prefabPayload, transform.position, aimReticle.transform.rotation);
	// }
}
