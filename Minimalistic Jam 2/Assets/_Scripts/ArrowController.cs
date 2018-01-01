using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowController : ProjectileController 
{
	override public void Launch()
	{ 
		Collider2D shooterCollider = shooter.GetComponentInChildren<Collider2D>();
		Physics2D.IgnoreCollision(GetComponent<Collider2D>(), shooterCollider, true);
		Physics2D.IgnoreCollision(shooterCollider, GetComponent<Collider2D>(), true);
		collider2D.enabled = true;
		rigidbody2D.velocity = direction * moveVelocity;
	}

	void Update()
	{
		 transform.rotation = Quaternion.AngleAxis(Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg, Vector3.forward);
	}

	override public void PlayerResponse()
	{
		// Score Points
		GameController.Instance.Score((int) shooter.GetComponent<PlayerController>().playerNum);
		Destroy(gameObject); 
	}

	override public void BoundaryResponse() 
	{
		Destroy(gameObject); 
	}
}
