using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionMaster {

	public enum Action {Tidy, Reset, EndTurn, EndGame};

	//private int[] bowls = new int[21]; //array used to store bowls
	public int bowl = 1;  //bowl number

	public Action Bowl (int pins) {
		if (pins < 0 || pins > 10) {throw new UnityException("Invalid number of pins");}

		// If last bowl (23rd)
		// Returns Action.EndTurn to complete score;

		if (bowl == 23) {
			bowl++;
			return Action.EndTurn;
		}

		// If after last bowl (23rd)
		// Returns Action.EndGame;

		if (bowl > 23) {
			return Action.EndGame;
		}

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
