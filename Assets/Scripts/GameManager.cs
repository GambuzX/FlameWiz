using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public List<int> pins = new List<int>();
    public bool ballLeftBox = false;
    private PinCounter pinCounter;
    private PinSetter pinSetter;
    private ActionMaster actionMaster = new ActionMaster();
    private ScoreMaster scoreMaster = new ScoreMaster();
    private Animator animator;
    private Text pinDisplay;
    private Ball ball;
    private int lastStandingCount = -1;
    private float lastChangeTime;

    void Start () {
        pinCounter = GameObject.FindObjectOfType<PinCounter>();
        pinSetter = GameObject.FindObjectOfType<PinSetter>();
        pinDisplay = GameObject.Find("Pin Counter").GetComponent<Text>();
        ball = GameObject.FindObjectOfType<Ball>();
    }
	
	void Update () {
        pinDisplay.text = pinCounter.CountStanding().ToString();

        if (ballLeftBox)
        {
           pinDisplay.color = Color.red;
           CheckStanding();
        }

		if (ball.GetComponent<Rigidbody> ().velocity.magnitude == 0f) {
			ball.Reset();
		}
    }

    public void CheckStanding()
    {
        //Update the lastStandingCount
        //Call PinsHaveSettled() when they have
        int currentStanding = pinCounter.CountStanding();

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
        int fallenPins = pinCounter.FallenPins();
        pinCounter.lastSettledCount = pinCounter.CountStanding();

        pins.Add(fallenPins); //Adiciona a jogada à lista "pins"

        ActionMaster.Action action = actionMaster.Bowl(pins);
        pinSetter.actionAnimation(action);

        pinDisplay.color = Color.green;
        lastStandingCount = -1;
        ballLeftBox = false;
        ball.Reset();
    }





}
