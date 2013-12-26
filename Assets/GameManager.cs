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
	public static float cursorSpeed = 8f;

	// Use this for initialization
	void Start () {
		for (int i = 0; i < numberOfChars; i++) {
			GameObject Char = Instantiate(character, new Vector3(-8.5f, -4.5f + i, 0), Quaternion.identity) as GameObject;
			characters.Add(Char);
			Char.tag = "NPC";
		}

		if (numberOfPlayers == 1) {
			createPlayer("1");
		}
		else if (numberOfPlayers == 2) {
			createPlayer("1");
			createPlayer("2");
		}
		else if (numberOfPlayers == 3) {
			createPlayer("1");
			createPlayer("2");
			createPlayer("3");
		}
		else if (numberOfPlayers == 4) {
			createPlayer("1");
			createPlayer("2");
			createPlayer("3");
			createPlayer("4");
		}
		else {
			// nothing happens
		}

		for (int i = 0; i < numberOfPlayers; i++) {
			GameObject Cursor = Instantiate(cursor, new Vector3(0, 1f - numberOfPlayers + i * 2, -0.1f), Quaternion.identity) as GameObject;
			int j = i + 1;
			Cursor.tag = j.ToString();
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
