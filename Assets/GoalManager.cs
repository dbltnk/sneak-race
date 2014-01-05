using UnityEngine;
using System.Collections;

public class GoalManager : MonoBehaviour {

	bool hasScored = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Vector2 pointA = new Vector2(this.transform.position.x - 0.5f, this.transform.position.y - 5f);
		Vector2 pointB = new Vector2(this.transform.position.x + 0.5f, this.transform.position.y + 5f);
		Collider2D[] hitObjects = Physics2D.OverlapAreaAll(pointA, pointB);
		if (hitObjects.Length > 0) {
			foreach(Collider2D c in hitObjects)	{
//				Debug.Log("Collided with: " + c.collider2D.gameObject.name);
				if (c.tag != "NPC" && hasScored == false) {
					hasScored = true;
					GameManager.score[c.tag] += 1;
				}
				GameManager gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
				gameManager.gameIsPlaying = false;
			}		
		}
	}
}
