using UnityEngine;
using System.Collections;

public class DestroyByContact : MonoBehaviour {
	public GameObject sphere;

	void OnCollisionEnter(Collision col){
		if (col.gameObject.name == "Cube") {
			GameObject cube = GameObject.Find ("Cube");
			CubeHealth other = (CubeHealth) cube.GetComponent(typeof(CubeHealth));
			int health = other.GetHealth();
			health = health - 50;
			other.SetHealth (health);

			Debug.Log ("******" + health);
			Destroy (sphere);
			if (health < 1) {
				Destroy (col.gameObject);
			}
		}
	}
}
