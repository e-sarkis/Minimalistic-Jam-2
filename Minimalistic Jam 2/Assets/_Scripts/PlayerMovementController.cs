using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Controls Player Movement as Derived from respective Controller Input
/// </summary>
public class PlayerMovementController : MonoBehaviour 
{
	public float strokeForce = 10f;
	[HideInInspector] public Vector2 axisInputDirection;

	void Update()
	{
		axisInputDirection = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
		axisInputDirection.Normalize();
		Debug.DrawRay(Vector3.zero, axisInputDirection, Color.white, 1);

		float zRot = Mathf.Atan2(axisInputDirection.x, -axisInputDirection.y) * Mathf.Rad2Deg;

		if (!Input.GetButton("Aim"))
		{
			if (axisInputDirection != Vector2.zero) transform.rotation = Quaternion.Euler(new Vector3(0, 0, zRot - 90f));
			if (Input.GetButtonDown("Stroke"))
			{
				GetComponent<Rigidbody2D>().AddForce(transform.right * strokeForce);
			}
		}


		
	}
}
