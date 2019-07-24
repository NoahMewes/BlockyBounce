using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tile5Move : MonoBehaviour {

    public float rightLimit;
    public float leftLimit;
    public float speed = 2.0f;
    private int direction = 1;
    private Vector3 movement;

    // Use this for initialization
    void Start () {
        rightLimit = transform.position.x + 3;
        leftLimit = transform.position.x - 3;

    }
	
	// Update is called once per frame
	void Update () {
        
        if (transform.position.x > rightLimit)
        {
            direction = -1;
        }
        else if (transform.position.x < leftLimit)
        {
            direction = 1;
        }
        movement = Vector3.right * direction * speed * Time.deltaTime;
        transform.Translate(movement);
    }
}
