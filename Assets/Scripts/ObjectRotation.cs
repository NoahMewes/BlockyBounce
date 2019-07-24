using UnityEngine;
using System.Collections;

public class ObjectRotation : MonoBehaviour {

	public float rotate = 1.0f;
	public float rotateSpeed = 1.0f;
	//public Rigidbody rb;

	void Start () {
		//rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.timeScale != 0){
			this.transform.rotation = Quaternion.Euler(0.0f, 0.0f, rotate);
			rotate += rotateSpeed;
		}
	}
}
