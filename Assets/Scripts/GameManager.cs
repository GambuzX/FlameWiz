using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public List<int> pins;

    private PinCounter pinCounter;
    private PinSetter pinSetter;
    private ActionMaster actionMaster;
    private Animator animator;
    private Text pinDisplay;
    private Ball ball;

    public bool ballLeftBox = false;


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
            pinSetter.CheckStanding();
        }
    }

    




}
