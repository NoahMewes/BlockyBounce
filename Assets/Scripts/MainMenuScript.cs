using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuScript : MonoBehaviour {

	public Rigidbody rb;

	public float upwards = 2.0f; 
	public float forwards = 2.0f; 
	public float downwards = -9.8f; 
	public float defGrav = -9.8f;
	public float buttonGrav = -9.8f;


	void start(){
		rb = GetComponent<Rigidbody>();
		rb.freezeRotation = true;
		rb.velocity = new Vector3 (forwards, defGrav, 0.0f);
	}
	// Update is called once per frame
	void Update () {
		//if (Input.GetKeyDown("space")){
		//	Physics.gravity = new Vector3(0.0f, buttonGrav,0.0f);
		//}

	}

	void OnCollisionEnter(Collision col){
		//if (col.gameObject.tag == "Obstacle") {
		//	Destroy (this.gameObject);
		//}
		if ((col.gameObject.tag != "Hitbox")) {
			rb.velocity = new Vector3 (forwards, upwards, 0.0f);
		}
		//Debug.Log ("Collided");
		Physics.gravity = new Vector3(0.0f,defGrav,0.0f);
	}
}
