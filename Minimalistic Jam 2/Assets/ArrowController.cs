using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowController : ProjectileController 
{
	override public void Launch()
	{ 
		rigidbody2D.velocity = direction * moveVelocity;
	}
}
