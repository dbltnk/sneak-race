using UnityEngine;
using System.Collections;

public class CharacterManager : MonoBehaviour {

	bool hasCommand = false;
	public enum MoveState {
		STOPPED = 0,
		WALKING = 1,
		RUNNING = 2,
	};
	public MoveState moveState = MoveState.STOPPED;


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

		GameManager gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
		float wlkspd = gameManager.walkSpeed;
		float rnspd = gameManager.runSpeed;
		if (gameManager.gameIsPlaying == false) {
			wlkspd = 0;
			rnspd = 0;
		}

		if (moveState == MoveState.WALKING) {
			transform.Translate(Vector3.right * Time.deltaTime * wlkspd);
		}
		else if (moveState == MoveState.RUNNING) {
			transform.Translate(Vector3.right * Time.deltaTime * rnspd);
		}
		else {
			// nothing happens
		}
	}
	
	IEnumerator pickCommand() {
		this.hasCommand = true;
		GameManager gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
		float mindur = gameManager.minWalkDuration;
		float maxdur = gameManager.maxWalkDuration;
		float time = Random.Range (mindur, maxdur);
		float randomNumber = Random.Range(-1f,2f);
		if (randomNumber <=0) {
			moveState = MoveState.WALKING;
		}
		else {
			moveState = MoveState.STOPPED;
		}
		yield return new WaitForSeconds(time);
		this.hasCommand = false;
		moveState = MoveState.STOPPED;
//		}
	}

	void playerInput(string tag) {
		if (Input.GetButton("A_" + tag) || Input.GetButton("B_" + tag)) {
			moveState = MoveState.WALKING;
		}
		else if (Input.GetButton("X_" + tag) || Input.GetButton("Y_" + tag)) {
			moveState = MoveState.RUNNING;
		}
		else {
			moveState = MoveState.STOPPED;
		}
	}
}
