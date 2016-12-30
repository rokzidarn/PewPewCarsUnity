using UnityEngine;
using System.Collections;

public class CubeHealth : MonoBehaviour {
	public int health;

	public int GetHealth(){
		return health;
	}
	public void SetHealth(int h){
		health = h;
	}
}
