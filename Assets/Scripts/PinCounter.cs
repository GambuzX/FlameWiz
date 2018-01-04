using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinCounter : MonoBehaviour {


    private int lastSettledCount = 10;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


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


//TODO Send the pinfall to the GameManager