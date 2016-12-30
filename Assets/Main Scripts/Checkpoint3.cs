using UnityEngine;
using System.Collections;

public class Checkpoint3 : MonoBehaviour {
	private bool c3R;

	public bool GetCheckpoint3Reached(){
		return c3R;	
	}
	public void SetCheckpoint3Reached(bool val){
		c3R = val;	
	}
	void OnTriggerEnter(Collider other){
		Checkpoint1 c1 = (Checkpoint1)(GameObject.Find ("Checkpoint1")).GetComponent(typeof(Checkpoint1));
		bool c1r = c1.GetCheckpoint1Reached ();
		Checkpoint2 c2 = (Checkpoint2)(GameObject.Find ("Checkpoint2")).GetComponent(typeof(Checkpoint2));
		bool c2r = c2.GetCheckpoint2Reached ();
		if (c1r && c2r) {
			SetCheckpoint3Reached (true);
		}
	}
}
