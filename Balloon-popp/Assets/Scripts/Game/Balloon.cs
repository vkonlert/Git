using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Balloon : MonoBehaviour
{

	//Анимация взрыва шарика (Система частиц)
	public ParticleSystem explosion;
	//Аудиоклип взрыва шарика
	public AudioClip explosionsound;

	Score score;
	Rigidbody2D rigidBody;
	SpriteRenderer spriteRenderer;

	float currenttime;
	//скорость шарика
	float speed;
	//минимальный размер шарика
	float minsize;

	void Start ()
	{

		currenttime = 0f;
		speed = 0f;
		minsize = 1f;

		rigidBody = GetComponent<Rigidbody2D> ();
		spriteRenderer = GetComponent<SpriteRenderer> ();
		score = GameObject.FindObjectOfType<Score> ();
		SetColor ();
		SetSize ();
		AddVelocity ();

	}

	void Update ()
	{
		
		currenttime += Time.deltaTime;


		if (currenttime >= 5f) {

			//Уровень сложности игры №2
			//Каждые 5 секунд начальная скорость шарика увеличивается на 0.1
			speed = Mathf.Clamp (speed += 0.1f, 0f, 2f);

			//Уровень сложности игры №3
			//Каждые 5 секунд диапазон начального размера шарика увеличивается на 0.1 (на самом деле мы видим декремент, но диапазон увеличивается)
			//Шарик может быть довольно маленьким, что в него сложно попасть
			minsize = Mathf.Clamp (minsize -= 0.1f, 0.5f, 2f);

			//Обнуление начального времени
			currenttime = 0;
		}

	}

	//Обработка нажатия мышки по шарику
	void OnMouseDown ()
	{
		//увеличение счета
		score.ScoreIncrement ();
		Explode ();   
	}

	//взрыв шарика
	void Explode ()
	{
		var circleCollider = GetComponent<CircleCollider2D> ();

		//уничтожение компонентов, так как шарик уничтожен, ему не нужны следующие компоненты
		//rigidbody - шарик больше не может двигаться по силе притяжения
		//spriterenderer - шарик не должен отображаться
		//circlecollider - шарик не должен сталкиваться с другими объектами
		Destroy (rigidBody);
		Destroy (spriteRenderer);
		Destroy (circleCollider);

		//Запуск звука взрыва шарика
		AudioSource.PlayClipAtPoint (explosionsound, transform.position);
		//Запуск анимации взрыва шарика
		explosion.Play ();

		//Уничтожение всего объекта и задержка на время анимации 
		Destroy (gameObject, explosion.main.duration);
	}

	//Добавление начальной скорости (смещение по оси x и y)
	void AddVelocity ()
	{

		rigidBody.velocity = new Vector2 (Random.Range (-8f, 8f), speed);

	}

	//Момент окончания игры
	//При столкновении шарпика с верхней границей, игра заканчивается. Т.е. загружается сцена конца игры
	void OnCollisionEnter2D (Collision2D collision)
	{

		if (collision.gameObject.tag == "TopBorder") {

			SceneManager.LoadScene ("EndGame_scene", LoadSceneMode.Single);
		}
        
	}

	//Задать цвет шарика
	void SetColor ()
	{
		spriteRenderer.color = Random.ColorHSV (0f, 1f, 1f, 1f, 0.5f, 1f);
	}

	//Задать размер шарика
	void SetSize ()
	{
		float size = Random.Range (minsize, 2f);
		transform.localScale = new Vector3 (size, size, 1);
	}
}
