using UnityEngine;
using System.Collections;

public class Rotator : MonoBehaviour {

	public float rotationSpeed;
	
	void Update () {
		transform.Rotate(new Vector3(0, 0, 45) * Time.deltaTime * rotationSpeed);
	}
}
