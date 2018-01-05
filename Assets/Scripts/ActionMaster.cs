using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionMaster {

	public enum Action {Tidy, Reset, EndTurn, EndGame};

    private GameManager gameManager;
	//private int[] bowls = new int[21]; //array used to store bowls
	private int bowl = 1; 

    void Start ()
    {
        gameManager = GameObject.FindObjectOfType<GameManager>();
    }



	public Action Bowl (List<int> plays) {
        
        int pins = plays[bowl - 1];
        int play19, play20;

        if (bowl < 19) { play19 = 0; } else { play19 = plays[18]; }
        if(bowl < 20) { play20 = 0; } else { play20 = plays[19]; }

        if (pins < 0 || pins > 10) {
			throw new UnityException ("Invalid number of pins");
		}
        
		//Handle last frame special cases

		if (bowl >= 21) {
			return Action.EndGame;
		}	else if (bowl == 20 && play19 == 10 && play20 != 10) {  //If 19th bowl was a strike and 20th is not, return Tidy
				bowl++;
				return Action.Tidy;
		}	else if (bowl >= 19 && (play19 + play20 >= 10)) { //If Strike or Spare in last set, reset and add1 to bowl
				bowl++;
				return Action.Reset;
		} else if (bowl == 20 && !(play19 + play20 >= 10)) {
				return Action.EndGame;	}

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

	/*private bool isLastBowlAwarded(){
		return (pins[18] + pins[19] >= 10);
	}*/
}
