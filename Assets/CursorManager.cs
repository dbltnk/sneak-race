using UnityEngine;
using System.Collections;

public class CursorManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (this.tag == "1") {
			renderer.material.color = new Vector4(0.75f,0.1f,0.1f,1);
			Vector3 movement = new Vector3(Input.GetAxis("L_XAxis_1"),-1 * Input.GetAxis("L_YAxis_1"),0);
			transform.Translate(movement * Time.deltaTime * GameManager.cursorSpeed);

			if (Input.GetAxis("TriggersL_1") > 0.3f || Input.GetAxis("TriggersR_1") > 0.3f || Input.GetButton("LB_1") || Input.GetButton("RB_1")) {
				renderer.material.color = new Vector4(1f,1f,1f,1);

				Vector2 point = new Vector2(this.transform.position.x, this.transform.position.y);
				Collider2D[] hitObjects = Physics2D.OverlapPointAll(point);
				if (hitObjects.Length > 0) {
					foreach(Collider2D c in hitObjects)	{
						//Debug.Log("Collided with: " + c.collider2D.gameObject.name);
//						Debug.Log(c.tag);
						foreach (GameObject cur in GameManager.cursors) {
							if (cur && cur.tag == c.tag) {
								Destroy(cur);
							}
						}
						Destroy(c.collider2D.transform.root.gameObject);
					}
				}
				Destroy(this.transform.root.gameObject);
			}
		}
		else if (this.tag == "2") {
			renderer.material.color = new Vector4(0.1f,0.1f,0.75f,1);
			Vector3 movement = new Vector3(Input.GetAxis("L_XAxis_2"),-1 * Input.GetAxis("L_YAxis_2"),0);
			transform.Translate(movement * Time.deltaTime * GameManager.cursorSpeed);

			if (Input.GetAxis("TriggersL_2") > 0.3f || Input.GetAxis("TriggersR_2") > 0.3f || Input.GetButton("LB_2") || Input.GetButton("RB_2")) {
				renderer.material.color = new Vector4(1f,1f,1f,1);

				Vector2 point = new Vector2(this.transform.position.x, this.transform.position.y);
				Collider2D[] hitObjects = Physics2D.OverlapPointAll(point);
				if (hitObjects.Length > 0) {
					foreach(Collider2D c in hitObjects)	{
						//Debug.Log("Collided with: " + c.collider2D.gameObject.name);
						Destroy(c.collider2D.transform.root.gameObject);
					}
				}
				Destroy(this.transform.root.gameObject);
			}
		}
		else if (this.tag == "3") {
			renderer.material.color = new Vector4(0.1f,0.75f,0.1f,1);
			Vector3 movement = new Vector3(Input.GetAxis("L_XAxis_3"),-1 * Input.GetAxis("L_YAxis_3"),0);
			transform.Translate(movement * Time.deltaTime * GameManager.cursorSpeed);

			if (Input.GetAxis("TriggersL_3") > 0.3f || Input.GetAxis("TriggersR_3") > 0.3f || Input.GetButton("LB_3") || Input.GetButton("RB_3")) {
				renderer.material.color = new Vector4(1f,1f,1f,1);

				Vector2 point = new Vector2(this.transform.position.x, this.transform.position.y);
				Collider2D[] hitObjects = Physics2D.OverlapPointAll(point);
				if (hitObjects.Length > 0) {
					foreach(Collider2D c in hitObjects)	{
						//Debug.Log("Collided with: " + c.collider2D.gameObject.name);
						Destroy(c.collider2D.transform.root.gameObject);
					}
				}
				Destroy(this.transform.root.gameObject);
			}
		}
		else if (this.tag == "4") {
			renderer.material.color = new Vector4(0.75f,0.75f,0.1f,1);
			Vector3 movement = new Vector3(Input.GetAxis("L_XAxis_4"),-1 * Input.GetAxis("L_YAxis_4"),0);
			transform.Translate(movement * Time.deltaTime * GameManager.cursorSpeed);

			if (Input.GetAxis("TriggersL_4") > 0.3f || Input.GetAxis("TriggersR_4") > 0.3f || Input.GetButton("LB_4") || Input.GetButton("RB_4")) {
				renderer.material.color = new Vector4(1f,1f,1f,1);

				Vector2 point = new Vector2(this.transform.position.x, this.transform.position.y);
				Collider2D[] hitObjects = Physics2D.OverlapPointAll(point);
				if (hitObjects.Length > 0) {
					foreach(Collider2D c in hitObjects)	{
						//Debug.Log("Collided with: " + c.collider2D.gameObject.name);
						Destroy(c.collider2D.transform.root.gameObject);
					}
				}
				Destroy(this.transform.root.gameObject);
			}
		}
		else {
			// nothing happens
		}
	}
}
