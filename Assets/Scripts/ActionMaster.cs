using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionMaster {

	public enum Action {Tidy, Reset, EndTurn, EndGame};

	private int[] bowls = new int[21]; //array used to store bowls
	public int bowl = 1;  //bowl number

	public Action Bowl (int pins) {
		if (pins < 0 || pins > 10) {
			throw new UnityException ("Invalid number of pins");
		}

		bowls [bowl - 1] = pins;


		//Handle last frame special cases

		if (bowl >= 21) {
			return Action.EndGame;
		}	else if (bowl == 20 && bowls[19-1]== 10 && bowls[20-1] != 10) {  //If 19th bowl was a strike and 20th is not, return Tidy
				bowl++;
				return Action.Tidy;
		}	else if (bowl >= 19 && isLastBowlAwarded ()) { //If Strike or Spare in last set, reset and add1 to bowl
				bowl++;
				return Action.Reset;
		} else if (bowl == 20 && !isLastBowlAwarded()) {
				return Action.EndGame;	}
<<<<<<< HEAD
=======

		// Strike

		if (pins == 10) {
			bowl += 2;
			return Action.EndTurn;
		}
>>>>>>> master

		// If first bowl of frame
		// Return Action.Tidy;
		if (bowl % 2 != 0) { // First Bowl of frame
			if (pins == 10) {
				bowl += 2;
				return Action.EndTurn;
			} else {
				bowl++;
				return Action.Tidy;
			}
		} else if (bowl % 2 == 0) { // If second bowl of frame Return Action.EndTurn;
			bowl++;
			return Action.EndTurn;
		}

		throw new UnityException ("Not sure what action to return");
	}

	private bool isLastBowlAwarded(){
		return (bowls [19 - 1] + bowls [20 - 1] >= 10);
	}
}
