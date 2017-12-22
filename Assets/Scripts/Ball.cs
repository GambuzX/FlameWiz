using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(Ball))]
public class Ball : MonoBehaviour {

	public float speedFactor;

	private Vector3 startPosition;
	private Rigidbody ballBody;
	private AudioSource ballSound;

    public bool hasLaunched = false;

	// Use this for initialization
	void Start () {
		ballBody = GetComponent<Rigidbody> ();
		ballSound = GetComponent<AudioSource> ();
        ballBody.useGravity = false;
		startPosition = transform.position;
	}

	public void Launch (Vector3 velocity)
	{
        if (!hasLaunched) {
            ballBody.velocity = velocity; // * speedFactor;
            ballSound.Play();
            ballBody.useGravity = true;
            hasLaunched = true;
        }
	}

	public void Reset(){
		hasLaunched = false;
		ballBody.velocity = Vector3.zero;
		ballBody.angularVelocity = Vector3.zero;	
		this.transform.position = startPosition;
		ballBody.useGravity = false;
	}
}
