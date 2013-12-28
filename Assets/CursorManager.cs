using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CursorManager : MonoBehaviour {

	Dictionary<string, Vector4> colors = new Dictionary<string, Vector4>();
	public Vector4 color1 = new Vector4(0.75f,0.1f,0.1f,1);
	public Vector4 color2 = new Vector4(0.1f,0.1f,0.75f,1);
	public Vector4 color3 = new Vector4(0.1f,0.75f,0.1f,1);
	public Vector4 color4 = new Vector4(0.75f,0.75f,0.1f,1);

	// Use this for initialization
	void Start () {
		colors.Add("1", color1);
		colors.Add("2", color2);
		colors.Add("3", color3);
		colors.Add("4", color4);
	}

	// Update is called once per frame
	void Update () {
		controlCursor(this.tag);
	}

	void controlCursor(string name) {
		renderer.material.color = colors[this.tag];

		Vector3 movement = new Vector3(Input.GetAxis("L_XAxis_" + name),-1 * Input.GetAxis("L_YAxis_" + name),0);
		float crsrspd = GameObject.Find("GameManager").GetComponent<GameManager>().cursorSpeed;
		transform.Translate(movement * Time.deltaTime * crsrspd);

		if (Input.GetAxis("TriggersL_" + name) > 0.3f || Input.GetAxis("TriggersR_" + name) > 0.3f || Input.GetButton("LB_" + name) || Input.GetButton("RB_" + name)) {
			renderer.material.color = new Vector4(1f,1f,1f,1);
			
			Vector2 point = new Vector2(this.transform.position.x, this.transform.position.y);
			Collider2D[] hitObjects = Physics2D.OverlapPointAll(point);
			if (hitObjects.Length > 0) {
				foreach(Collider2D c in hitObjects)	{
					// Debug.Log("Collided with: " + c.collider2D.gameObject.name);
					// Debug.Log(c.tag);
					List<GameObject> crsrs = GameObject.Find("GameManager").GetComponent<GameManager>().cursors;
					foreach (GameObject cur in crsrs) {
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



}
