using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static 	class ScoreMaster {
    

    //return a list of individual frame scores, NOT CUMULATIVES
    public static List<int> ScoreFrames (List<int> rolls)
    {
        List<int> frameList = new List<int>();

		for (int i = 1; i < rolls.Count; i += 2) {
			if (frameList.Count == 10) {break;}				//If scoreboard already full, break
			
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
