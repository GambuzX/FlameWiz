using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pin : MonoBehaviour {

	public float standingThreshold = 9f;
	public bool isRaised = false;


	public bool IsStanding(){
		float tiltX = Mathf.Abs(this.transform.rotation.eulerAngles.x);         //eulerAngles devolve sempre positivo. -6.0º = 354º
		float tiltZ = Mathf.Abs(this.transform.rotation.eulerAngles.z);

		if ((tiltX < standingThreshold) && (tiltZ < standingThreshold)) {
			return true;
		} else {
			return false;	
		}
	}
}
