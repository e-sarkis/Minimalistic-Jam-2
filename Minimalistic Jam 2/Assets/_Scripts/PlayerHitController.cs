using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHitController : MonoBehaviour 
{
	void OnCollisionEnter2D(Collision2D other)
	{
		switch (other.gameObject.tag)
		{
			case "Projectile":
				ProjectileResponse(other.gameObject);
				break;
			default:
				break;
		}
	}

	void ProjectileResponse(GameObject projectile)
	{
		Destroy(gameObject);	// TODO - Integrate with GameController
	}
}
