using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Balloonspawn : MonoBehaviour
{

	public GameObject ballon;
	//текущее время
	float currenttime;
	//время между запуском шариков
	float waittime;

	void Start ()
	{
		//запуск параллельной функции
		StartCoroutine (Delay ());
		currenttime = 0f;
		waittime = 2f;

	}

	void Update ()
	{

		//увеличение текущего времени с каждым фреймом
		currenttime += Time.deltaTime;

		//Увеличение уровня сложности №1
		//Каждые 10 секунд шарик щапускается на 0.1 секунды быстрее
		if (currenttime >= 10f) {
			waittime = Mathf.Clamp (waittime -= 0.1f, 0.1f, 2f);
			currenttime = 0;
		}
	}

	//запуск шарика
	void Spawn ()
	{
		//место появление шарика генерируется случайным образом
		Vector3 position = new Vector3 (Random.Range (-8f, 8f), -6f, 0);
		//копирование шарика
		Instantiate (ballon, position, Quaternion.identity);

	}

	//задержка
	IEnumerator Delay ()
	{
		
		for (;;) {
			yield return new WaitForSeconds (waittime);
			Spawn ();
		}
		
	}
}
