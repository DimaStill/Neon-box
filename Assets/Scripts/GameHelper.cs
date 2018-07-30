using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameHelper : MonoBehaviour {
	public float secondWait;
	public float amountScore;
	public Text amountScoreText;
	public GameObject platform;
	public Material[] platformMaterials;
	float timer;
	float speed;
	public float speedPlatform = 1;
	// Use this for initialization
	void Start () {
		amountScore = 0;
	}
	
	// Update is called once per frame
	void Update () {
		Timer ();
		Spawn ();
		IncreaseSpeed ();
		amountScoreText.text = ((int) amountScore).ToString ();
	}

	void Spawn () {
		if (timer <= 0) {
			GenerateColorPlatform ();
			// Генерация расположения платформы
			float xFirstLine = Random.Range (-9.0f, 9.0f);
			platform.transform.position = new Vector3 (xFirstLine, -6, 0);
			GameObject.Instantiate (platform);
			// Генерация второй сегмент (линию) платформы
			if (xFirstLine != 0) { // Если первая платформа не по центру, то создаем вторую линию (платформу) на этом же уровне
				float xSecondLine = 0;
				if (xFirstLine < 0) // Правее от первой
					xSecondLine = Random.Range (xFirstLine + 15, 15.0f);
				else if (xFirstLine > 0) // Левее от первой
					xSecondLine = Random.Range (-15.0f, xFirstLine - 15);
				platform.transform.position = new Vector3 (xSecondLine, -6, 0);
				GameObject.Instantiate (platform);
			}
			timer = secondWait;
		}
	}

	void Timer () {
		timer -= Time.deltaTime;
		if (secondWait > 2.5)
			secondWait -= speed * Time.deltaTime;
		else
			secondWait = 2.5f;
	}

	void GenerateColorPlatform () {
		int indexMaterials = Random.Range(0, 4); 
		platform.GetComponent<LineRenderer>().material = platformMaterials[indexMaterials]; 
	}

	void IncreaseSpeed () {
		speed += 0.01f * Time.deltaTime;

		speedPlatform += 0.04f * Time.deltaTime;
		platform.GetComponent<PlatformHelper> ().speed = speedPlatform;
	}

	public void Restart () {
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}
}
