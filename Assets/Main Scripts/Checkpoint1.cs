using UnityEngine;
using System.Collections;

public class Checkpoint1 : MonoBehaviour {
	private bool c1R;
	private int lapCount;
	public int numLaps;
	public GUIText lapText;

	public bool GetCheckpoint1Reached(){
		return c1R;	
	}
	public void SetCheckpoint1Reached(bool val){
		c1R = val;	
	}
	void Start(){
		lapCount = 0;
		lapText.text = "LAP " + lapCount + "/" + numLaps;
		SetCheckpoint1Reached (true);
		Checkpoint2 c2 = (Checkpoint2)(GameObject.Find ("Checkpoint2")).GetComponent(typeof(Checkpoint2));
		c2.SetCheckpoint2Reached (true);
		Checkpoint3 c3 = (Checkpoint3)(GameObject.Find ("Checkpoint3")).GetComponent(typeof(Checkpoint3));
		c3.SetCheckpoint3Reached (true);
	}
	void OnTriggerEnter(Collider other){
		SetCheckpoint1Reached (true);
		Checkpoint2 c2 = (Checkpoint2)(GameObject.Find ("Checkpoint2")).GetComponent(typeof(Checkpoint2));
		bool c2r = c2.GetCheckpoint2Reached ();
		Checkpoint3 c3 = (Checkpoint3)(GameObject.Find ("Checkpoint3")).GetComponent(typeof(Checkpoint3));
		bool c3r = c3.GetCheckpoint3Reached ();
		if (GetCheckpoint1Reached () && c2r && c3r) {
			c2.SetCheckpoint2Reached (false);
			c3.SetCheckpoint3Reached (false);
			lapCount++;
			lapText.text = "LAP " + lapCount + "/" + numLaps;
		}
		if (lapCount == numLaps + 1) {
			lapText.text = "GAME OVER";
		}
	}
}
