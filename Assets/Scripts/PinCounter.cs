using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinCounter : MonoBehaviour {


    public int lastSettledCount = 10;
    
    public int CountStanding()
    {
        int pinCount = 0;
        foreach (Pin pin in GameObject.FindObjectsOfType<Pin>())
        {
            if (pin.IsStanding())
            {
                pinCount++;
            }
        }
        return pinCount;
    }

    public int FallenPins()
    {
        int standingPins = CountStanding();
        int fallenPins = lastSettledCount - standingPins;
        lastSettledCount = standingPins;

        return fallenPins;
    }
}
