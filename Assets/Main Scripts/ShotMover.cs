using UnityEngine;
using System.Collections;

public class ShotMover : MonoBehaviour {
	public float speed;

	void Update () {
		//Rigidbody rb = GetComponent<Rigidbody>();
		//rb.velocity = rb.transform.forward * Time.deltaTime * speed;
		transform.position += transform.forward * Time.deltaTime * speed;
	}
}
