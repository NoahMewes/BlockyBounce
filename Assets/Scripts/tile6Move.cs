using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tile6Move : MonoBehaviour {

    public float topLimit;
    public float bottomLimit;
    public float speed = 2.0f;
    private int direction = 1;
    private Vector3 movement;

    // Use this for initialization
    void Start()
    {
        topLimit = 2.5f;
        bottomLimit = 0.25f;

    }

    // Update is called once per frame
    void Update()
    {

        if (transform.position.y > topLimit)
        {
            direction = -1;
        }
        else if (transform.position.y < bottomLimit)
        {
            direction = 1;
        }
        movement = Vector3.up * direction * speed * Time.deltaTime;
        transform.Translate(movement);
    }
}