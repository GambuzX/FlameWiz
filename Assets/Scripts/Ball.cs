using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(Ball))]
public class Ball : MonoBehaviour {

	public float speedFactor;

	private Rigidbody ballBody;
	private AudioSource ballSound;

    public bool hasLaunched = false;

	// Use this for initialization
	void Start () {
		ballBody = GetComponent<Rigidbody> ();
		ballSound = GetComponent<AudioSource> ();
        ballBody.useGravity = false;
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

    private void Update()
    {
        if (this.transform.position.y < 10.85)
        {
            this.transform.position = new Vector3(transform.position.x, 10.86f, transform.position.z);
        }
    }

}
