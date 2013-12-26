using UnityEngine;
using System.Collections;

public class CursorManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (this.tag == "1") {
			Vector3 movement = new Vector3(Input.GetAxis("L_XAxis_1"),-1 * Input.GetAxis("L_YAxis_1"),0);
			transform.Translate(movement * Time.deltaTime * GameManager.cursorSpeed);
		}
		else if (this.tag == "2") {
			Vector3 movement = new Vector3(Input.GetAxis("L_XAxis_2"),-1 * Input.GetAxis("L_YAxis_2"),0);
			transform.Translate(movement * Time.deltaTime * GameManager.cursorSpeed);
		}
		else if (this.tag == "3") {
			Vector3 movement = new Vector3(Input.GetAxis("L_XAxis_3"),-1 * Input.GetAxis("L_YAxis_3"),0);
			transform.Translate(movement * Time.deltaTime * GameManager.cursorSpeed);
		}
		else if (this.tag == "4") {
			Vector3 movement = new Vector3(Input.GetAxis("L_XAxis_4"),-1 * Input.GetAxis("L_YAxis_4"),0);
			transform.Translate(movement * Time.deltaTime * GameManager.cursorSpeed);
		}
		else {
			// nothing happens
		}
	}
}
