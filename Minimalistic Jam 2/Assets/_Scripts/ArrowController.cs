using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowController : ProjectileController 
{
	override public void Launch()
	{ 
		Collider shooterCollider = shooter.GetComponent<Collider>();
		if (shooterCollider && collider2D) 
		{
			Physics.IgnoreCollision(GetComponent<Collider>(), shooterCollider, true);
			Physics.IgnoreCollision(shooterCollider, GetComponent<Collider>(), true);
			collider2D.enabled = true;
		}
		rigidbody2D.velocity = direction * moveVelocity;
	}

	void Update()
	{
		 transform.rotation = Quaternion.AngleAxis(Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg, Vector3.forward);
	}

	override public void PlayerResponse()
	{
		Destroy(gameObject); 
	}
}
