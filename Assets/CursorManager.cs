using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CursorManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
		GameManager gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
		renderer.material.color = gameManager.colors[this.tag];
	}

	// Update is called once per frame
	void Update () {
		controlCursor(this.tag);
	}

	void controlCursor(string name) {
		Vector3 movement = new Vector3(Input.GetAxis("L_XAxis_" + name),-1 * Input.GetAxis("L_YAxis_" + name),0);
		GameManager gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
		float crsrspd = gameManager.cursorSpeed;
		transform.Translate(movement * Time.deltaTime * crsrspd);

		if (Input.GetAxis("TriggersL_" + name) > 0.3f || Input.GetAxis("TriggersR_" + name) > 0.3f || Input.GetButton("LB_" + name) || Input.GetButton("RB_" + name)) {
			renderer.material.color = new Vector4(1f,1f,1f,1);
			
			Vector2 point = new Vector2(this.transform.position.x, this.transform.position.y);
			Collider2D[] hitObjects = Physics2D.OverlapPointAll(point);
			if (hitObjects.Length > 0) {
				foreach(Collider2D c in hitObjects)	{
					// Debug.Log("Collided with: " + c.collider2D.gameObject.name);
					// Debug.Log(c.tag);

					// destroy other character's corresponging cursor if it has one
					List<GameObject> crsrs = gameManager.cursors;
					foreach (GameObject cur in crsrs) {
						if (cur && cur.tag == c.tag) {
							Destroy(cur);
						}
					}

					// destroy the character that was hit
					Destroy(c.collider2D.gameObject);
				}
			}
			// destroy yourself (one shot only)
			Destroy(this.gameObject);
		}
	}



}
