using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

	// Use this for initialization
	public void StartGame () {

        SceneManager.LoadScene("Game");
		
	}
	
	// Update is called once per frame
	public void EndGame () {

        SceneManager.LoadScene("GameOver");
	}

    public void BackToMainMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }
}
