using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public List<int> bowls = new List<int>();
    public bool ballLeftBox = false;

    private PinSetter pinSetter;
    private Ball ball;
	private ScoreDisplay scoreDisplay;

    void Start () {
        pinSetter = GameObject.FindObjectOfType<PinSetter>();
		ball = GameObject.FindObjectOfType<Ball>();
		scoreDisplay = GameObject.FindObjectOfType<ScoreDisplay>();
    }
	
	void Update () {
		if ((ball.GetComponent<Rigidbody> ().velocity.magnitude == 0f) && ball.hasLaunched) {
			ball.Reset();
		}
    }

    public void Bowl(int pinFall)
    {
        bowls.Add(pinFall); //Adiciona a jogada à lista "pins"

        ActionMaster.Action action = ActionMaster.NextAction(bowls);
        pinSetter.triggerAnimation(action);

		scoreDisplay.UpdateScores (bowls);

        ball.Reset();
    }





}
