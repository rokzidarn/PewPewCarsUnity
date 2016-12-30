using UnityEngine;
using System.Collections;

public class Checkpoint2 : MonoBehaviour {
	private bool c2R;

	public bool GetCheckpoint2Reached(){
		return c2R;	
	}
	public void SetCheckpoint2Reached(bool val){
		c2R = val;	
	}
	void OnTriggerEnter(Collider other){
		Checkpoint1 c1 = (Checkpoint1)(GameObject.Find ("Checkpoint1")).GetComponent(typeof(Checkpoint1));
		bool c1r = c1.GetCheckpoint1Reached ();
		if (c1r) {
			SetCheckpoint2Reached (true);
		}
	}
}
