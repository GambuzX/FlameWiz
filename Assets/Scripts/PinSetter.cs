using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PinSetter : MonoBehaviour {
	
	private Text pinDisplay;

	private bool ballEnteredBox = false;

	// Use this for initialization
	void Start () {
		pinDisplay = GameObject.Find ("Pin Counter").GetComponent<Text> ();
	}
	
	// Update is called once per frame
	void Update () {
		pinDisplay.text = CountStanding().ToString ();

	}

	private int CountStanding ()
	{
		int pinCount = 0;

		foreach (Pin pin in GameObject.FindObjectsOfType<Pin>()) {
			if (pin.IsStanding ()) {
				pinCount++;
			}
		}
		return pinCount;
	}

	void OnTriggerEnter(Collider col) {
		if (col.GetComponent<Ball> ()) {
			pinDisplay.color = Color.red;
			ballEnteredBox = true;
		}
	}

	void OnTriggerExit(Collider col) {
		Pin pin = col.GetComponentInParent<Pin>();
		if (pin)
		{
			Destroy(pin.gameObject);
		}
	}
}
