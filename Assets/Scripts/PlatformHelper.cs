using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformHelper : MonoBehaviour {
	public float speed;

	public float startSpeed;
	GameHelper gameHelper;
	// Use this for initialization
	void Start () {
		speed = startSpeed;
		gameHelper = GameObject.FindObjectOfType<GameHelper> ();
	}
	
	// Update is called once per frame
	void Update () {
		Move ();
		//IncreaseSpeed ();
	}

	void Move () {
		transform.position = new Vector2(transform.position.x, transform.position.y + speed * Time.deltaTime);
		if (CheckExitAboard ()) {
			Destroy (this.gameObject);
			gameHelper.amountScore += 0.5f;
		}
	}


	bool CheckExitAboard () {
		if (transform.position.y >= 5.6f)
			return true;
		return false;
	}

	/*void IncreaseSpeed () {
		speed += (0.1f * Time.deltaTime);
		//Debug.Log (speed2);
	}*/
}
