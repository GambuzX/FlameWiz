using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreMaster {
    

    //return a list of individual frame scores, NOT CUMULATIVES
    public static List<int> ScoreFrames (List<int> rolls)
    {
        List<int> frameList = new List<int>();

       /* int bowl = 1;

        foreach (int roll in rolls)
        {
            if (roll == 10 && bowl >= 19)
            {
                scores.Add(10);
            }
            else if (roll == 10)
            {
                scores.Add(10);
                scores.Add(0);
            }
            else
            {
                scores.Add(roll);
            }
        }*/
        //Code here
        //Do this using TDD
        //Returns scores for each frame
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
