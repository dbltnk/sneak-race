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

	// Use this for initialization
	void Start () {
		for (int i = 0; i < numberOfChars; i++) {
			GameObject Char = Instantiate(character, new Vector3(-5, -4.5f + i, 0), Quaternion.identity) as GameObject;
			characters.Add(Char);
			Char.tag = "NPC";
		}

		int randomNumber = Random.Range(0,numberOfChars-1);
		characters[randomNumber].tag = "Player1";
	}


	
	// Update is called once per frame
	void Update () {
	
	}
}
