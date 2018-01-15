using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreMaster {
    

    //return a list of individual frame scores, NOT CUMULATIVES
    public static List<int> ScoreFrames (List<int> rolls)
    {
        List<int> frameList = new List<int>();
        //Code here
        //Do this using TDD
        //Returns scores for each frame

        //Rules -> Strike: Adds to frame the score of the next frame (max 2 frames forward)
        //      -> Spare: Adds to frame the score of the first bowl in next frame 

        int sum = 0;
        bool secondFrame = false;
        bool strike = false;
        int previousRoll = 0;
        int strikeCumulative = 0;

        foreach (int roll in rolls) {
            if (secondFrame) {
                sum += roll;

                if (strike) { //if last frame was a strike
                    int value = strikeCumulative + sum;
                    frameList.Add(value);
                    strike = false;
                }

                if (sum >= 10) //spare
                {
                    previousRoll = 10; //stores value
                }
                else //not spare
                {
                    frameList.Add(sum);
                }                
                sum = 0;
                secondFrame = false;
            }
            else { //first frame           
                if (roll == 10) //if strike
                {
                    strike = true;
                    strikeCumulative += 10;
                }
                else {
                    sum += roll;
                    secondFrame = true;
                    if (previousRoll == 10) //if last frame scored 10 pins
                    {
                        int previousScore = 10 + roll;
                        frameList.Add(previousScore);
                        previousRoll = 0;
                    }
                }
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
