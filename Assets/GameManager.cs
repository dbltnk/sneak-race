using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour {

	public static Dictionary<string, int> score = new Dictionary<string, int>();

	public bool gameIsPlaying = true;
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
	public bool showNames = false;
	public GameObject character;
	public Dictionary<string, Color> colors = new Dictionary<string, Color>();
	public Color color1 = new Color(0.75f,0.1f,0.1f,1);
	public Color color2 = new Color(0.1f,0.1f,0.75f,1);
	public Color color3 = new Color(0.1f,0.75f,0.1f,1);
	public Color color4 = new Color(0.75f,0.75f,0.1f,1);

	// Use this for initialization
	void Start () {

		if (numberOfPlayers > numberOfChars) {
			throw new UnityException("more players than chars");
		}

		for (int i = 0; i < numberOfChars; i++) {
			GameObject Char = Instantiate(character, new Vector3(-8.5f, -4.5f + i, 0), Quaternion.identity) as GameObject;
			characters.Add(Char);
			Char.tag = "NPC";
		}
		
		for (int i = 0; i < numberOfPlayers; i++) {
			int j = i + 1;
			createPlayer(j.ToString());
			if (score.ContainsKey(j.ToString()) == false) {
				score.Add(j.ToString(), 0);
			}
			GameObject Cursor = Instantiate(cursor, new Vector3(0, 1f - numberOfPlayers + i * 2, -0.1f), Quaternion.identity) as GameObject;
			Cursor.tag = j.ToString();
			cursors.Add(Cursor);
		}

		colors.Add("1", color1);
		colors.Add("2", color2);
		colors.Add("3", color3);
		colors.Add("4", color4);
	}


	// Update is called once per frame
	void Update () {
		if (gameIsPlaying) {
			showNames = false;
		}
		else {
			showNames = true;
			if (Input.anyKeyDown) {
				Invoke("resetGame", 3f);
			}
		}
	}

	void OnGUI () {
		string scoreDisplay = "";

		for (int i = 0; i < numberOfPlayers; i++) {
			int j = i + 1;
			scoreDisplay += string.Format("Player #{0}: {1} ", j, score[j.ToString()]);
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
		Application.LoadLevel(Application.loadedLevel);
	}
}
