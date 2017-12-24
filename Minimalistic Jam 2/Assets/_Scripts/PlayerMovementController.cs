using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Controls Player Movement as Derived from respective Controller Input
/// </summary>
public class PlayerMovementController : MonoBehaviour 
{
	public float strokeForce = 10f;
	
	private PlayerController playerController;
	void Awake() { playerController = GetComponent<PlayerController>(); }

	void Update()
	{
		Debug.DrawRay(Vector3.zero, playerController.axisInputDirection, Color.white, 1);

		float zRot = Mathf.Atan2(playerController.axisInputDirection.x, -playerController.axisInputDirection.y) * Mathf.Rad2Deg;

		if (!playerController.inputAim)
		{
			if (playerController.axisInputDirection != Vector2.zero)
			{
				transform.rotation = Quaternion.Euler(new Vector3(0, 0, zRot - 90f));
			}
			if (playerController.inputStroke)
			{
				GetComponent<Rigidbody2D>().AddForce(transform.right * strokeForce);
			}
		}
	}
}
