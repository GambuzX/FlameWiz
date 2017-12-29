using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionMaster {

	public enum Action {Tidy, Reset, EndTurn, EndGame};

	//private int[] bowls = new int[21]; //array used to store bowls
	public int bowl = 1;  //bowl number

	private bool allPinsFellLastSet = false;
	private int firstTwoBowlsLastSet = 0;

	public Action Bowl (int pins) {
		if (pins < 0 || pins > 10) {throw new UnityException("Invalid number of pins");}

		// If sum of first 2 bowls of last set are equal to ten (spare)
		// Returns Action.EndTurn;

		if (bowl == 19 && pins != 10) {
			firstTwoBowlsLastSet += pins;
		}

		if (bowl == 20 && pins != 10) {
			int pinTotal = firstTwoBowlsLastSet + pins;

			if (pinTotal == 10) {
				allPinsFellLastSet = true;
				bowl++;
				return Action.EndTurn;
			}
		}

		// If on 20th bowl and not all pins have fallen in the last set
		// Returns Action.EndGame;

		if (bowl == 20 && !allPinsFellLastSet) {
			return Action.EndGame;
		}

		// If strike on 19th play, does not jump to bowl 21. Instead goes on to 20th
		// Returns Action.EndTurn

		if (bowl == 19 && pins == 10) {
			allPinsFellLastSet = true;
			bowl++;
			return Action.EndTurn;
		}

		// If strike on 20th bowl goes on to 21st
		// Returns Action.EndTurn

		if (bowl == 20 && pins == 10) {
			allPinsFellLastSet = true;
			bowl++;
			return Action.EndTurn;
		}

		// If last bowl (21st)
		// Returns Action.EndTurn to complete score;

		if (bowl >= 21) {
			bowl++;
			return Action.EndGame;
		}

		// Strike

		if (pins == 10) {
			bowl += 2;
			return Action.EndTurn;
		}

		// If first bowl of frame
		// Return Action.Tidy;
		if (bowl % 2 != 0) { // Mid frame (or last frame)
			bowl++;
			return Action.Tidy;
		} else if (bowl % 2 == 0) { // If second bowl of frame Return Action.EndTurn;
			return Action.EndTurn;
		}

		throw new UnityException ("Not sure what action to return");
	}
}
