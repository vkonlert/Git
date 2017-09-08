using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Game_Scene : MonoBehaviour
{
	public Text scoretext;
	int currentscore;
	EndGame_scene endgame_scene;

	public Button mainscreen;

	void Start ()
	{
		mainscreen.onClick.AddListener (HandleClickMainScreen);

	}

	void HandleClickMainScreen ()
	{
		SceneManager.LoadScene ("Main_scene", LoadSceneMode.Single);
  
	}
}
