using UnityEngine;
using System.Collections;

public class MoveAI : MonoBehaviour {
	public GameObject[] waypoints;
	public int curr = 0; //start at waypoint 0
	public float speed;
	public float minDistance;
	private float rspeed;
	private float rminDistance;

	void Start(){
		rspeed = speed;
		rminDistance = minDistance;
	}
		
	void Update () {
		float distance = Vector3.Distance(gameObject.transform.position, waypoints[curr].transform.position); //distance between waypoints
		if(distance > rminDistance){ //moving
			gameObject.transform.LookAt(waypoints[curr].transform.position);
			gameObject.transform.position += gameObject.transform.forward * Time.deltaTime * rspeed;
			//TODO make it more random, realistic turns
		}
		else{ //at the waypoint
			if (curr == waypoints.Length-1) {
				curr = 0; //from the beginning
			} else {
				curr++; //next waypoint
			}
			rspeed = Random.Range(speed-2.0f, speed+2.0f); //random to be more interesting
			rminDistance = Random.Range(minDistance-0.5f, minDistance+0.5f);
		}
	}
}
