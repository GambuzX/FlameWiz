using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

	private Ball fireBall;

	private Vector3 offset;

	void Start () {
		fireBall = GameObject.FindObjectOfType<Ball> ();	
		offset = new Vector3 (fireBall.transform.position.x - this.transform.position.x, fireBall.transform.position.y - this.transform.position.y, fireBall.transform.position.z- this.transform.position.z);
	}
	
	// Update is called once per frame
	void Update () {
		
		if (fireBall.transform.position.z <= 1829) { //In front of headpin --> Camera stops when it reaches it 
			this.transform.position = new Vector3  (this.transform.position.x, fireBall.transform.position.y - offset.y, fireBall.transform.position.z - offset.z);
            //this.transform.position = fireBall.transform.position - offset;
        }

        this.transform.position = new Vector3 (Mathf.Clamp(transform.position.x, -40f, 40f), transform.position.y, transform.position.z);
	}

    public void MoveCamera(float xNudge)
    {
        this.transform.Translate(new Vector3(xNudge, 0, 0));
    }
}
