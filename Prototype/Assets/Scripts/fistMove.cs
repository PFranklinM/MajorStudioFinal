using UnityEngine;
using System.Collections;

public class fistMove : MonoBehaviour {

	public GameObject fist;

	private int timer = 0;

	public float moveAmount = 10f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		Vector3 moving = new Vector3 (transform.position.x,
		                              transform.position.y,
		                              transform.position.z);


		if (timer < 10) {
			timer++;
			moving.x += moveAmount * Time.deltaTime;
		} else if (timer >= 10) {
			Destroy(fist);
		}

		if (Input.GetButtonUp ("PS_Square")) {
			timer = 0;
		}

		transform.position = moving;
	
	}
}
