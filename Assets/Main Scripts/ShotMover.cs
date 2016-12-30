using UnityEngine;
using System.Collections;

public class ShotMover : MonoBehaviour {
	public float speed;

	void Update () {
		transform.position += transform.forward * Time.deltaTime * speed;
	}
}
