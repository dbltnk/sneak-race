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
	}
	
	// Update is called once per frame
	void Update () {
		if (this.tag == "NPC") {
			if (this.hasCommand == false) {
				StartCoroutine("pickCommand"); 
			}
		}
		else {
			playerInput(this.tag);
		}

		float wlkspd = GameObject.Find("GameManager").GetComponent<GameManager>().walkSpeed;
		float rnspd = GameObject.Find("GameManager").GetComponent<GameManager>().runSpeed;

		if (this.isWalking) {
			transform.Translate(Vector3.right * Time.deltaTime * wlkspd);
		}
		else if (this.isRunning) {
			transform.Translate(Vector3.right * Time.deltaTime * rnspd);
		}
		else {
			// nothing happens
		}
	}
	
	IEnumerator pickCommand() {
		this.hasCommand = true;
		float mindur = GameObject.Find("GameManager").GetComponent<GameManager>().minWalkDuration;
		float maxdur = GameObject.Find("GameManager").GetComponent<GameManager>().maxWalkDuration;
		float time = Random.Range (mindur, maxdur);
		float randomNumber = Random.Range(-1f,2f);
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

	void playerInput(string tag) {
		if (Input.GetButton("A_" + tag) || Input.GetButton("B_" + tag)) {
			this.isWalking = true;
			this.isRunning = false;
		}
		else if (Input.GetButton("X_" + tag) || Input.GetButton("Y_" + tag)) {
			this.isWalking = false;
			this.isRunning = true;
		}
		else {
			this.isWalking = false;
			this.isRunning = false;
		}
	}
}
