using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour {

	public int numberOfPlayers;
	public int numberOfChars;
	public float cursorSpeed = 8f;
	public float walkSpeed = 0.5f;
	public float runSpeed = 1f;
	public float minWalkDuration = 0.05f;
	public float maxWalkDuration = 1f; 
	public List<GameObject> characters = new List<GameObject>();
	public GameObject cursor;
	public List<GameObject> cursors = new List<GameObject>();
	public static Dictionary<string, int> score = new Dictionary<string, int>();
	string scoreDisplay = "lalala";
	public static bool resetNow = false;
	public bool showNames = false;
	public GameObject character;

	// Use this for initialization
	void Start () {
		for (int i = 0; i < numberOfChars; i++) {
			GameObject Char = Instantiate(character, new Vector3(-8.5f, -4.5f + i, 0), Quaternion.identity) as GameObject;
			characters.Add(Char);
			Char.tag = "NPC";
		}

		for (int i = 0; i < numberOfPlayers; i++) {
			int j = i + 1;
			createPlayer(j.ToString());
			score.Add(j.ToString(), 0);
			GameObject Cursor = Instantiate(cursor, new Vector3(0, 1f - numberOfPlayers + i * 2, -0.1f), Quaternion.identity) as GameObject;
			Cursor.tag = j.ToString();
			cursors.Add(Cursor);
		}
	}


	// Update is called once per frame
	void Update () {
		if (resetNow == true) {
			StartCoroutine("WaitThenReset");
		}
	}

	IEnumerator WaitThenReset() {
		showNames = true;
		float w = walkSpeed;
		float r = runSpeed;
		float c = cursorSpeed;
		walkSpeed = 0;
		runSpeed = 0;
		cursorSpeed = 0;
		yield return new WaitForSeconds(5.0f);
		showNames = false;
		walkSpeed = w;
		runSpeed = r;
		cursorSpeed = c;
		resetGame();
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

		if (showNames == true) {
			foreach (GameObject c in characters) {
				if (c) {
					Vector3 pos = Camera.main.WorldToScreenPoint(c.transform.position);
					pos.y = Screen.height - pos.y;
					GUI.Label(new Rect(pos.x-30,pos.y,100,100), c.tag);
				}
			}
		}

		foreach (GameObject c in cursors) {
			if (c) {
				Vector3 pos = Camera.main.WorldToScreenPoint(c.transform.position);
				pos.y = Screen.height - pos.y;
				GUI.Label(new Rect(pos.x+20,pos.y+20,100,100), c.tag);
			}
		}
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
//		Debug.Log("reset");
		foreach(GameObject c in characters)	{
			if (c) {
				Destroy(c);
			}
		}
		characters.Clear();
		foreach(GameObject d in cursors)	{
			if (d) {
				Destroy(d);
			}
		}
		cursors.Clear();
		for (int i = 0; i < numberOfChars; i++) {
			GameObject Char = Instantiate(character, new Vector3(-8.5f, -4.5f + i, 0), Quaternion.identity) as GameObject;
			characters.Add(Char);
			Char.tag = "NPC";
		}
		for (int i = 0; i < numberOfPlayers; i++) {
			int j = i + 1;
			createPlayer(j.ToString());
			GameObject Cursor = Instantiate(cursor, new Vector3(0, 1f - numberOfPlayers + i * 2, -0.1f), Quaternion.identity) as GameObject;
			Cursor.tag = j.ToString();
			cursors.Add(Cursor);
		}
	}
}
