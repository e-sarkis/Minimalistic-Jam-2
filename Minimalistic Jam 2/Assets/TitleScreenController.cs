using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScreenController : MonoBehaviour 
{
	public string nextSceneName;

	void Update()
	{
		if (Input.GetButton("Select"))
		{
			SceneManager.LoadScene(nextSceneName);
		}
	}
}
