﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PinSetter : MonoBehaviour {
	
	private Text pinDisplay;
	private bool ballEnteredBox = false;
	private float lastChangeTime;
	private Ball ball;

	public int lastStandingCount = -1;
	public float distanceToRaise = 40f;
	public GameObject pinSet;

	// Use this for initialization
	void Start () {
		pinDisplay = GameObject.Find ("Pin Counter").GetComponent<Text> ();
		ball = GameObject.FindObjectOfType<Ball> ();
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


	// Update is called once per frame
	void Update () {
		pinDisplay.text = CountStanding().ToString ();

		if (ballEnteredBox) {
			CheckStanding ();
		}

	}

	void CheckStanding(){
		//Update the lastStandingCount
		//Call PinsHaveSettled() when they have
		int currentStanding = CountStanding ();

		if (currentStanding != lastStandingCount) {
			lastChangeTime = Time.time;
			lastStandingCount = currentStanding;
			return;
		}

		if ((Time.time - lastChangeTime) >= 3) {  //if 3 seconds pass after no pin falls
			PinsHaveSettled();
		}
	}

	void PinsHaveSettled() {
		pinDisplay.color = Color.green;
		lastStandingCount = -1;
		ballEnteredBox = false;
		ball.Reset ();
	}

	public void RaisePins() {
		//raise standing pins by distanceToRaise

		foreach (Pin pin in GameObject.FindObjectsOfType<Pin>()) {
			if (pin.IsStanding()) {
				pin.transform.Translate (0f, distanceToRaise, 0f);
				pin.isRaised = true;
				pin.GetComponent<Rigidbody> ().useGravity = false;
			}
		}
	}

	public void LowerPins(){
		//lower raised pins to floor
		foreach (Pin pin in GameObject.FindObjectsOfType<Pin>()) {
			if (pin.isRaised) {
				pin.transform.Translate (0f, -distanceToRaise, 0f);
				pin.isRaised = false;
				pin.GetComponent<Rigidbody> ().useGravity = true;
			}
		}
	}

	public void RenewPins(){
		//places new pins
		Instantiate(pinSet, new Vector3(0f, 0f, 1829f), Quaternion.identity);
	}
}
