using UnityEngine;
using System.Collections;

public class ShotMover : MonoBehaviour {
	public float speed;

	void Update () {
		Rigidbody rb = GetComponent<Rigidbody>();
		//rb.velocity = transform.forward * Time.deltaTime * speed;
		transform.position += Vector3.forward * Time.deltaTime * speed;
	}
}
