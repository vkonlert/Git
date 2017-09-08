using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Score : MonoBehaviour
{

	Text scoretext;
	int currentscore;

	void Start ()
	{

		currentscore = 0;
		scoretext = gameObject.GetComponent<Text> (); 
		scoretext.text = "Score : " + currentscore;

	}
     
	void Update ()
	{
		//изменение счета на label
		scoretext.text = "Score : " + currentscore;  
		//сохранение счета в PlayerPrefs
		PlayerPrefs.SetInt ("Player Score", currentscore);

	}

	//увеличение счета
	public void ScoreIncrement ()
	{

		currentscore += 10;

	}

}
