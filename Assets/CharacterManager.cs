using UnityEngine;
using System.Collections;

public class CharacterManager : MonoBehaviour {

	bool hasCommand = false;
	bool isWalking = false;
	bool isRunning = false;

	// Use this for initialization
	void Start () {
		float r = Random.Range(0f,1f);
		float g = Random.Range(0f,1f);
		float b = Random.Range(0f,1f);
		renderer.material.color = new Vector4(r,g,b,1);
//		Debug.Log(this.tag);
	}
	
	// Update is called once per frame
	void Update () {
		if (this.tag == "NPC") {
			if (this.hasCommand == false) {
				StartCoroutine("pickCommand"); 
			}
		}
		else {
			playerInput();
		}

		if (this.isWalking) {
			transform.Translate(Vector3.right * Time.deltaTime * GameManager.walkSpeed);
		}
		else if (this.isRunning) {
			transform.Translate(Vector3.right * Time.deltaTime * GameManager.runSpeed);
		}
		else {
			// nothing happens
		}
	}
	
	IEnumerator pickCommand() {
		this.hasCommand = true;
		float time = Random.Range (GameManager.minWalkDuration, GameManager.maxWalkDuration);
		float randomNumber = Random.Range(-1f,1f);
		if (randomNumber <=0) {
			this.isWalking = true;
		}
		else {
			this.isWalking = false;
		}
		yield return new WaitForSeconds(time);
		this.hasCommand = false;
		this.isWalking = false;
//		}
	}

	void playerInput() {
		if (this.tag == "1") {
			if (Input.GetButton("A_1") || Input.GetButton("B_1")) {
				this.isWalking = true;
				this.isRunning = false;
			}
			else if (Input.GetButton("X_1") || Input.GetButton("Y_1")) {
				this.isWalking = false;
				this.isRunning = true;
			}
			else {
				this.isWalking = false;
				this.isRunning = false;
			}
		}
		else if (this.tag == "2") {
			if (Input.GetButton("A_2") || Input.GetButton("B_2")) {
				this.isWalking = true;
				this.isRunning = false;
			}
			else if (Input.GetButton("X_2") || Input.GetButton("Y_2")) {
				this.isWalking = false;
				this.isRunning = true;
			}
			else {
				this.isWalking = false;
				this.isRunning = false;
			}
		}
		else if (this.tag == "3") {
			if (Input.GetButton("A_3") || Input.GetButton("B_3")) {
				this.isWalking = true;
				this.isRunning = false;
			}
			else if (Input.GetButton("X_3") || Input.GetButton("Y_3")) {
				this.isWalking = false;
				this.isRunning = true;
			}
			else {
				this.isWalking = false;
				this.isRunning = false;
			}
		}
		else if (this.tag == "4") {
			if (Input.GetButton("A_4") || Input.GetButton("B_4")) {
				this.isWalking = true;
				this.isRunning = false;
			}
			else if (Input.GetButton("X_4") || Input.GetButton("Y_4")) {
				this.isWalking = false;
				this.isRunning = true;
			}
			else {
				this.isWalking = false;
				this.isRunning = false;
			}
		}
	}
}
