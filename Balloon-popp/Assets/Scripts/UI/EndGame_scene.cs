using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class EndGame_scene : MonoBehaviour
{
	public Text scoretext;
	public Button playagain;
	public Button mainscreen;
	public Button exit;

	void Start ()
	{
		playagain.onClick.AddListener (HandleClickPlayAgain);
		mainscreen.onClick.AddListener (HandleClickMainScreen);
		exit.onClick.AddListener (HandleClickExit);

		//отображение счета на label
		scoretext.text = "Score : " + PlayerPrefs.GetInt ("Player Score");

	}

	void HandleClickPlayAgain ()
	{

		SceneManager.LoadScene ("Game_scene", LoadSceneMode.Single);
  
	}

	void HandleClickMainScreen ()
	{

		SceneManager.LoadScene ("Main_scene", LoadSceneMode.Single);
  
	}

	void HandleClickExit ()
	{
		Application.Quit ();
	}

}
