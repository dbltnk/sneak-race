﻿using UnityEngine;
using System.Collections;

public class CharacterManager : MonoBehaviour {

	public bool hasCommand = false;
	public bool isWalking = false;

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
		else if (this.tag == "Player1") {
			if (Input.GetKey("space")) {
				this.isWalking = true;
			}
			else {
				this.isWalking = false;
			}
		}
		else {
			// nothing happens
		}

		if (this.isWalking) {
			transform.Translate(Vector3.right * Time.deltaTime * GameManager.walkSpeed);
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
}
