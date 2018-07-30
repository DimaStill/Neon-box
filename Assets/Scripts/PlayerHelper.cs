using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHelper : MonoBehaviour {
	public float speed;
	public GameObject panel;
	public Text gameOverScore;
	public Material[] playerMaterials;
	GameHelper gameHelper;
	// Use this for initialization
	void Start () {
		GetComponent<LineRenderer> ().material = playerMaterials [1];
	}
	
	// Update is called once per frame
	void Update () {
		CheckPressArrowButton ();
		CheckPressNumbersButton ();
		IncreaseSpeed ();
	}

	void Move (float moveSpeed) {
		transform.position = new Vector2(transform.position.x + moveSpeed, transform.position.y);
	}

	void CheckPressArrowButton () {
		float newSpeed = speed * Time.deltaTime;
		if (Input.GetKey (KeyCode.LeftArrow))
			Move (-newSpeed);
		else if (Input.GetKey (KeyCode.RightArrow))
			Move (newSpeed);
	}

	void CheckPressNumbersButton () {
		if (Input.GetKey (KeyCode.Alpha1))
			ChangeColor (0);
		else if (Input.GetKey (KeyCode.Alpha2))
			ChangeColor (1);
		else if (Input.GetKey (KeyCode.Alpha3))
			ChangeColor (2);
		else if (Input.GetKey (KeyCode.Alpha4))
			ChangeColor (3);
	}

	void ChangeColor (int indexColor) {
		this.GetComponent<LineRenderer>().material = playerMaterials[indexColor]; 
	}

	void OnTriggerEnter2D(Collider2D collider)
	{
		Material playerMaterial = GetComponent<LineRenderer> ().material;
		Material platformMaterial = collider.gameObject.GetComponent<LineRenderer> ().material;
		if (playerMaterial.ToString () != platformMaterial.ToString ()) {
			Destroy (this.gameObject);
			panel.SetActive (true);
			gameHelper = GameObject.FindObjectOfType<GameHelper> ();
			gameOverScore.text = ((int) gameHelper.amountScore).ToString();
		}
	}

	void IncreaseSpeed () {
		speed += (0.02f * Time.deltaTime);
	}
}
