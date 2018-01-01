using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileController : MonoBehaviour 
{
	public GameObject shooter;	// The Player who fired this projectile
	public GameObject target;	// The Target of this projectile

	public Rigidbody2D rigidbody2D;
	public Collider2D collider2D;

	public Vector2 direction;

	public float moveVelocity	= 0.5f;

	void Awake()
	{
		rigidbody2D = GetComponent<Rigidbody2D>();
		collider2D = GetComponent<Collider2D>();
		if (collider2D) collider2D.enabled = false; // Collisions Enabled during Launch
	}

	virtual public void Launch() {  }

	void OnCollisionEnter2D(Collision2D other)
	{
		switch (other.gameObject.tag)
		{
			case "Player":
				PlayerResponse();
				break;
			case "Boundary":
				BoundaryResponse();
				break;
			default:
				break;
		}
	}

	virtual public void PlayerResponse() { }
	virtual public void BoundaryResponse() { }
}
