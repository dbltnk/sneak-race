using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour {

	public GameObject character;
	public int numberOfChars;
	public static float walkSpeed = 0.5f;
	public static float runSpeed = 1f;
	public static float minWalkDuration = 0.05f;
	public static float maxWalkDuration = 1f; 
	public List<GameObject> characters = new List<GameObject>();
	public GameObject cursor;
	public List<GameObject> cursors = new List<GameObject>();
	public int numberOfPlayers;

	// Use this for initialization
	void Start () {
		for (int i = 0; i < numberOfChars; i++) {
			GameObject Char = Instantiate(character, new Vector3(-8.5f, -4.5f + i, 0), Quaternion.identity) as GameObject;
			characters.Add(Char);
			Char.tag = "NPC";
		}

		if (numberOfPlayers == 1) {
			createPlayer("Player1");
		}
		else if (numberOfPlayers == 2) {
			createPlayer("Player1");
			createPlayer("Player2");
		}
		else if (numberOfPlayers == 3) {
			createPlayer("Player1");
			createPlayer("Player2");
			createPlayer("Player3");
		}
		else if (numberOfPlayers == 4) {
			createPlayer("Player1");
			createPlayer("Player2");
			createPlayer("Player3");
			createPlayer("Player4");
		}
		else {
			// nothing happens
		}

		for (int i = 0; i < numberOfPlayers; i++) {
			GameObject Cursor = Instantiate(cursor, new Vector3(0, 1f - numberOfPlayers + i * 2, 0), Quaternion.identity) as GameObject;
			cursors.Add(cursor);
		}

	}


	
	// Update is called once per frame
	void Update () {
	
	}

	void createPlayer(string playerName) {
		int randomNumber = Random.Range(0,numberOfChars-1);
		if (characters[randomNumber].tag == "NPC") {
			characters[randomNumber].tag = playerName;
		}
		else {
			Debug.Log("already a player");
			createPlayer(playerName);
		}
	}
}
