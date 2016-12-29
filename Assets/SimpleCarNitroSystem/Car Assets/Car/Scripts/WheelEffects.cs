//this is an edited version of Unity's WheelEffects script.
//Instead of dealing with the hard namespace stuff,
//we're keeping this simple.
//in this version of WheelEffects, the car is just going to Instantiate the tire smoke object when
//the wheel collider reaches it's slip threshold.
using System.Collections;
using UnityEngine;

namespace UnityStandardAssets.Vehicles.Car
{
    public class WheelEffects : MonoBehaviour
    {
		public GameObject slipObject;
		public float slipThreshold = 0.3f;
		private WheelCollider thisWheel;

        private void Start()
        {
			thisWheel = GetComponent<WheelCollider> ();
        }

		public void Update()
		{
			EmitTyreSmoke ();
		}

        public void EmitTyreSmoke()
        {
			WheelHit hit;
			thisWheel.GetGroundHit (out hit);
			if (Mathf.Abs(hit.sidewaysSlip) > slipThreshold)
			{
				var smoke = Instantiate(slipObject.gameObject,transform.position,Quaternion.identity);
				Destroy(smoke,1f);
			}
        }
    }
}
