using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreMaster {
    

    //return a list of individual frame scores, NOT CUMULATIVES
    public static List<int> ScoreFrames (List<int> rolls)
    {
        List<int> frameList = new List<int>();
        //Rules -> Strike: Adds to frame the score of the next 2 bowls
        //      -> Spare: Adds to frame the score of the first bowl in next frame 

		/*  CODE BEFORE WATCHING LESSON, DONE BY MYSELF
         * 
         * int rollsLength = rolls.Count;
        int bowl = 1;  //registers current bowl number
        
        for (int i = 0; i < rollsLength; i += 2)
        {
            int roll = rolls[i];
            int nextRoll = 0;
            int nextnextRoll = 0;
            bool nextRollValid = true;
            bool nextnextRollValid = true;

            if (i < (rollsLength - 2))
            {
                nextRoll = rolls[i + 1];
                nextnextRoll = rolls[i + 2];
                nextRollValid = true;
                nextnextRollValid = true;
            }
            else if (i < (rollsLength - 1))
            {
                nextRoll = rolls[i + 1];
                nextnextRollValid = false;
                nextRollValid = true;
            }
            else
            {
                nextRollValid = false;
                nextnextRollValid = false;
            }

            if (bowl == 19)
            {
                if (nextnextRollValid){
                    frameList.Add(roll + nextRoll + nextnextRoll);
                }
                else {
                    frameList.Add(roll + nextRoll);
                    }
                return frameList;
            }
            else if (roll == 10) //if strike
            {
                if (nextRollValid && nextnextRollValid)
                {
                    frameList.Add(10 + nextRoll + rolls[i + 2]);
					i--;
                }
            }
            else if ((roll + nextRoll) == 10) // if spare on set
            {
                if (nextnextRollValid)
                {
                    frameList.Add(10 + rolls[i + 2]);
                }
            }
            else
            {
                if (nextRollValid)
                {
                    frameList.Add(roll + nextRoll);
                }
            }
            bowl += 2;
        }*/

		// CODE AFTER WATCHING LESSON
		for (int i = 1; i < rolls.Count; i += 2) {
			
			if (rolls [i - 1] + rolls [i] < 10) { 			//Normal "open" frame
				frameList.Add (rolls [i - 1] + rolls [i]);
			}

			if (rolls.Count - i <= 1) {break;}				//Insufficient look-ahead

			if (rolls [i - 1] == 10) {						//STRIKE
				i--;										//Strike frame has just one bowl
				frameList.Add (10 + rolls [i + 1] + rolls [i + 2]);
			} else if (rolls [i - 1] + rolls [i] == 10) {	//Calculate SPARE bonus
				frameList.Add (10 + rolls [i + 1]);
			}
		}
        return frameList;
    }

    //returns a list of cumulative scores like a normal score card
    public static List<int> ScoreCumulative(List<int> rolls)
    {
        List<int> scores = new List<int>();
        int sum = 0;
        
        foreach (int frameScore in ScoreFrames(rolls)) {
            sum += frameScore;
            scores.Add(sum);            
        }
        return scores;
    }
}
