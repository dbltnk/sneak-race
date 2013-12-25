using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	public GameObject character;
	public int numberOfChars;
	public static float walkSpeed = 0.5f;
	public static float runSpeed = 1f;
	public static float minWalkDuration = 0.05f;
	public static float maxWalkDuration = 1f; 

	// Use this for initialization
	void Start () {
		for (int i = 0; i < numberOfChars; i++) {
			Instantiate(character, new Vector3(-5, -4.5f + i, 0), Quaternion.identity);
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
