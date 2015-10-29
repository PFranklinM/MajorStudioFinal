using UnityEngine;
using System.Collections;

public class playerMove : MonoBehaviour {

	public float moveAmount = 10f;

	public float jumpSpeed = 10f;

	public GameObject player;
	public GameObject floor;
	public GameObject fist;

	//ground teteer totter - pivot point in the middle (push it up from bottom with infinite jumps)
	//not button mashing
	//environmental hazard based on what the background is

	private int jumpCounter = 0;

	Rigidbody2D rb;

	// Use this for initialization
	void Start () {

		rb = GetComponent<Rigidbody2D>();
	
	}
	
	// Update is called once per frame
	void Update () {

		Vector3 moving = new Vector3 (transform.position.x,
		                              transform.position.y,
		                              transform.position.z);

		if (Input.GetAxis ("DPad_Horizontal") > 0) {
			moving.x += moveAmount * Time.deltaTime;
		}

//		if(Input.GetAxis ("Horizontal") > 0) {
//			moving.x += moveAmount * Time.deltaTime;
//		}

		if (Input.GetAxis ("DPad_Horizontal") < 0) {
			moving.x -= moveAmount * Time.deltaTime;
		}

//		if(Input.GetAxis ("Horizontal") < 0) {
//			moving.x -= moveAmount * Time.deltaTime;
//		}

		if(Input.GetButtonDown ("PS_X")){
			jumpCounter ++;
		}

		if (Input.GetButtonDown ("PS_X") && jumpCounter < 3){
			rb.velocity = new Vector3(0, 10, 0);
//			print (jumpCounter);
		}

		if (Input.GetButtonDown ("PS_Square")) {
			GameObject fist = Instantiate (Resources.Load ("Fist")) as GameObject;
			fist.transform.position = player.transform.position;
		}
	
	transform.position = moving;

		if (Input.GetKey (KeyCode.Return)) {
			Application.LoadLevel("Main");
		}
		
	}

	void OnCollisionEnter2D(Collision2D coll){
		if (coll.gameObject.tag == "ground") {
			jumpCounter = 0;
		}
	}
}
	