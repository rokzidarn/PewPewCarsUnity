using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	public GameObject shot;
	public Transform shotSpawn;
	public float fireRate;
	private float nextFire;
	public float lifetime;

	void Update (){
		if(Input.GetButton("Fire1") && Time.time > nextFire){
			nextFire = Time.time + fireRate;
			GameObject go = (GameObject)Instantiate (shot, shotSpawn.position, shotSpawn.rotation);
			Destroy (go, lifetime);
		}
	}
}
