using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Main_scene : MonoBehaviour
{

	public Button play;
	public Button exit;

	void Start ()
	{

		//событие нажатия кнопки
		play.onClick.AddListener (HandleClickPlay);
		exit.onClick.AddListener (HandleClickExit);

	}

	void HandleClickPlay ()
	{

		//загрузка сцены
		SceneManager.LoadScene ("Game_scene", LoadSceneMode.Single);
  
	}

	void HandleClickExit ()
	{

		//выход из  приложения
		Application.Quit ();
	}
}
