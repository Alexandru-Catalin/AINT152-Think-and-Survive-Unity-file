using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TheEnd : MonoBehaviour {

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void OnCollisionEnter2D(Collision2D other)
	{
		if (other.gameObject.tag == "Player")
		{
			//Application.LoadLevel (0);
			SceneManager.LoadScene(0);
			Destroy(gameObject);  // Destroys key
		}
	}
}
