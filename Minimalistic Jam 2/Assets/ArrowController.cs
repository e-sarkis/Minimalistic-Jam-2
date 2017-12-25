using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowController : ProjectileController 
{
	override public void Launch()
	{ 
		rigidbody2D.velocity = direction * moveVelocity;
	}

	void Update()
	{
		 transform.rotation = Quaternion.AngleAxis(Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg, Vector3.forward);
	}
}
