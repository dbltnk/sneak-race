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
	public static List<GameObject> cursors = new List<GameObject>();
	public int numberOfPlayers;
	public static float cursorSpeed = 8f;
	public static Dictionary<string, int> score = new Dictionary<string, int>();
	string scoreDisplay = "lalala";
	public static bool resetNow = false;

	// Use this for initialization
	void Start () {
		for (int i = 0; i < numberOfChars; i++) {
			GameObject Char = Instantiate(character, new Vector3(-8.5f, -4.5f + i, 0), Quaternion.identity) as GameObject;
			characters.Add(Char);
			Char.tag = "NPC";
		}

		if (numberOfPlayers == 1) {
			createPlayer("1");
			score.Add("1", 0);
		}
		else if (numberOfPlayers == 2) {
			createPlayer("1");
			score.Add("1", 0);
			createPlayer("2");
			score.Add("2", 0);
		}
		else if (numberOfPlayers == 3) {
			createPlayer("1");
			score.Add("1", 0);
			createPlayer("2");
			score.Add("2", 0);
			createPlayer("3");
			score.Add("3", 0);
		}
		else if (numberOfPlayers == 4) {
			createPlayer("1");
			score.Add("1", 0);
			createPlayer("2");
			score.Add("2", 0);
			createPlayer("3");
			score.Add("3", 0);
			createPlayer("4");
			score.Add("4", 0);
		}
		else {
			// nothing happens
		}

		for (int i = 0; i < numberOfPlayers; i++) {
			GameObject Cursor = Instantiate(cursor, new Vector3(0, 1f - numberOfPlayers + i * 2, -0.1f), Quaternion.identity) as GameObject;
			int j = i + 1;
			Cursor.tag = j.ToString();
			cursors.Add(Cursor);
		}
	}


	// Update is called once per frame
	void Update () {
		if (resetNow == true) {
			resetGame();
		}
	}

	void OnGUI () {

		if (numberOfPlayers == 1) {
			scoreDisplay = "Player #1: " + score["1"].ToString();
		}
		else if (numberOfPlayers == 2) {
			scoreDisplay = "Player #1: " + score["1"].ToString() + " Player #2: " + score["2"].ToString();
		}
		else if (numberOfPlayers == 3) {
			scoreDisplay = "Player #1: " + score["1"].ToString() + " Player #2: " + score["2"].ToString() + " Player #3: " + score["3"].ToString();
		}
		else if (numberOfPlayers == 4) {
			scoreDisplay = "Player #1: " + score["1"].ToString() + " Player #2: " + score["2"].ToString() + " Player #3: " + score["3"].ToString()+ " Player #4: " + score["4"].ToString();
		}
		else {
			// nothing happens
		}
		GUI.skin.label.fontSize = 30;
		GUI.Label(new Rect(600,10,10000,100), scoreDisplay);
	}

	void createPlayer(string playerName) {
		int randomNumber = Random.Range(0,numberOfChars-1);
		if (characters[randomNumber].tag == "NPC") {
			characters[randomNumber].tag = playerName;
		}
		else {
//			Debug.Log("already a player");
			createPlayer(playerName);
		}
	}

	void resetGame() {
		resetNow = false;
		Debug.Log("reset");
		foreach(GameObject c in characters)	{
			Destroy(c);
		}
		foreach(GameObject d in cursors)	{
			Destroy(d);
		}
		for (int i = 0; i < numberOfChars; i++) {
			GameObject Char = Instantiate(character, new Vector3(-8.5f, -4.5f + i, 0), Quaternion.identity) as GameObject;
			characters.Add(Char);
			Char.tag = "NPC";
			Debug.Log("done it");
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
		for (int i = 0; i < numberOfPlayers; i++) {
			GameObject Cursor = Instantiate(cursor, new Vector3(0, 1f - numberOfPlayers + i * 2, -0.1f), Quaternion.identity) as GameObject;
			int j = i + 1;
			Cursor.tag = j.ToString();
			cursors.Add(Cursor);
		}
	}
}
