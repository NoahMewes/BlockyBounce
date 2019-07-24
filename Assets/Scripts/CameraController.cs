using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

	public GameObject player;
	private float offset = 0.0f;
	public float offsetModifier = 0.0f;
	public float cameraY = 5.0f;
	public float cameraZ = 5.0f;



	// Use this for initialization
	void Start () {
		offset = (transform.position.x - player.transform.position.x) + offsetModifier;
	}

	// Update is called once per frame
	void LateUpdate () {
		Vector3 xPos = new Vector3 (player.transform.position.x + offset, cameraY, -cameraZ);
		transform.position = xPos;
	}
}
