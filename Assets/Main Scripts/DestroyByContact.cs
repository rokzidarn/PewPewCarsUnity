using UnityEngine;
using System.Collections;

public class DestroyByContact : MonoBehaviour {
	public GameObject sphere;
	public int damage;

	void OnCollisionEnter(Collision col){
		if (col.gameObject.name == "Cube") {
			CubeHealth cb= (CubeHealth)(GameObject.Find ("Cube")).GetComponent(typeof(CubeHealth));
			int health = cb.GetHealth();
			health = health - damage;
			cb.SetHealth (health);
			Debug.Log ("HEALTH: " + health);

			Destroy (sphere);
			if (health < 1) {
				Destroy (col.gameObject);
			}
		}
	}
}
