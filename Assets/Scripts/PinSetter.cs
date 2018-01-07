using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PinSetter : MonoBehaviour {
	
	private Animator animator;
    private ActionMaster actionMaster = new ActionMaster();
    private PinCounter pinCounter;
    private GameManager gameManager;

    public GameObject pinSet;
    public float distanceToRaise = 40f;

    void Start () {
		animator = this.GetComponent<Animator> ();
        pinCounter = GameObject.FindObjectOfType<PinCounter>();
        gameManager = GameObject.FindObjectOfType<GameManager>();
    }


	void OnTriggerExit(Collider col) {
		Pin pin = col.GetComponentInParent<Pin>();
		if (pin)
		{
			Destroy(pin.gameObject);
		}
	}	

    public void actionAnimation(ActionMaster.Action action) {

        if (action == ActionMaster.Action.Tidy)
        {
            animator.SetTrigger("tidyTrigger");
        }
        else if (action == ActionMaster.Action.Reset)
        {
            animator.SetTrigger("resetTrigger");
            pinCounter.lastSettledCount = 10;
        }
        else if (action == ActionMaster.Action.EndTurn)
        {
            animator.SetTrigger("resetTrigger");
            pinCounter.lastSettledCount = 10;
        }
        else if (action == ActionMaster.Action.EndGame)
        {
            throw new UnityException("Don't know how to handle end game yet");
        }
    }    

    public void RaisePins()
    {
        //raise standing pins by distanceToRaise

        foreach (Pin pin in GameObject.FindObjectsOfType<Pin>())
        {
            if (pin.IsStanding())
            {
                pin.transform.Translate(0f, distanceToRaise, 0f);
				pin.transform.eulerAngles.Set (0f, 0f, 0f);
                pin.isRaised = true;
                pin.GetComponent<Rigidbody>().useGravity = false;
            }
        }
    }

    public void LowerPins()
    {
        //lower raised pins to floor
        foreach (Pin pin in GameObject.FindObjectsOfType<Pin>())
        {
            if (pin.isRaised)
            {
                pin.transform.Translate(0f, -distanceToRaise, 0f);
                pin.isRaised = false;
                pin.GetComponent<Rigidbody>().useGravity = true;
            }
        }
    }

    public void RenewPins()
    {
        //places new pins
        Instantiate(pinSet, new Vector3(0f, 0f, 1829f), Quaternion.identity);
    }


}
