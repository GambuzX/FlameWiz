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

        //Rules -> Strike: Adds to frame the score of the next 2 bowls
        //      -> Spare: Adds to frame the score of the first bowl in next frame 

        int sum = 0;
        bool secondFrame = false;
        int previousRoll = 0;
        int strikeCumulative = 0;

        int rollsLength = rolls.Count;
        bool firstBowlOfSet = true;
        
        for (int i = 0; i < rollsLength; i++)
        {
            if (firstBowlOfSet)
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

                if (roll == 10) //if strike
                {
                    if (nextRollValid && nextnextRollValid)
                    {
                        frameList.Add(10 + nextRoll + rolls[i + 2]);
                    }
                }
                else if ((roll + nextRoll) == 10) // if spare on set
                {
                    if (nextnextRollValid)
                    {
                        frameList.Add(10 + rolls[i + 2]);
                        firstBowlOfSet = false;
                    }
                }
                else
                {
                    if (nextRollValid)
                    {
                        frameList.Add(roll + nextRoll);
                        firstBowlOfSet = false;
                    }
                }
            }
            else //if second bowl of set
            {
                firstBowlOfSet = true;
            }
        }

        /*foreach (int roll in rolls) {
            if (secondFrame) {
                sum += roll;

                if (strikeCumulative == 10) { //if last frame was a strike
                    int value = strikeCumulative + sum;
                    frameList.Add(value);
                    strikeCumulative = 0;
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
                    if (strikeCumulative >= 20)//if last two frames were strike
                    {
                        frameList.Add(30); //adds 30
                    } else
                    {
                        strikeCumulative += 10;
                        rolls.
                    }
                }
                else { //not a strike
                    if (strikeCumulative == 20) //if last two frames were strike and this bowl isnt
                    {
                        int score = 20 + roll;
                        frameList.Add(score);
                        strikeCumulative = 0;
                    }
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
        }*/
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
