using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PinCounter : MonoBehaviour {

    private Text pinDisplay;
    private GameManager gameManager;
    private int lastStandingCount = -1;
    private float lastChangeTime;

    public int lastSettledCount = 10;

    private void Start()
    {
        pinDisplay = GameObject.Find("Pin Counter").GetComponent<Text>();
        gameManager = GameObject.FindObjectOfType<GameManager>();
    }

    private void Update()
    {
        pinDisplay.text = CountStanding().ToString();

        if (gameManager.ballLeftBox)
        {
            Red();
            CheckStanding();
        }
    }

    public void CheckStanding()
    {
        //Update the lastStandingCount
        //Call PinsHaveSettled() when they have
        int currentStanding = CountStanding();

        if (currentStanding != lastStandingCount)
        {
            lastChangeTime = Time.time;
            lastStandingCount = currentStanding;
            return;
        }

        if ((Time.time - lastChangeTime) >= 3)
        {  //if 3 seconds pass after no pin falls
            PinsHaveSettled();
        }
    }

    void PinsHaveSettled()
    {
        // Determines what action to pass to PinSetter for the animation
        // Resets ball
        int standing = CountStanding();
        int fallenPins = lastSettledCount - standing;
        lastSettledCount = standing;

        gameManager.Bowl(fallenPins);

        Green();
        lastStandingCount = -1;
        gameManager.ballLeftBox = false;
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

    public void Red()
    {
        pinDisplay.color = Color.red;
    }

    public void Green()
    {
        pinDisplay.color = Color.green;
    }

    public void ResetLastSettledCount()
    {
        lastSettledCount = 10;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<Ball>())
        {
            gameManager.ballLeftBox = true;
        }
    }
}
