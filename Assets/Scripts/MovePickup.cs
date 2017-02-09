using UnityEngine;
using System.Collections;

public class MovePickup : MonoBehaviour {

	public float speed;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		// Movement is 1 to the left (-1)
		Vector3 movement = new Vector3(-1, 0);
		transform.position = transform.position + movement * speed;
	}
}
