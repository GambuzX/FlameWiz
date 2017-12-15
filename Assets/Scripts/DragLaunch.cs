using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragLaunch : MonoBehaviour {

    private Ball ball;
    private Vector3 dragStart, dragEnd;
    private float startTime, endTime;


    void Start () {
        ball = GetComponent<Ball>();
	}

    private void Update()
    {
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -42.15f, 42.15f), transform.position.y, transform.position.z);
    }
    public void DragStart() { //
        //capture time and position of drag start

        dragStart = Input.mousePosition;
        startTime = Time.time;
    }

    public void DragEnd() {
        //launch ball
        endTime = Time.time;
        float timeInterval = endTime - startTime;

        dragEnd = Input.mousePosition;
        Vector3 positionVar = dragEnd - dragStart;
        float launchSpeedX = (dragEnd.x - dragStart.x) / timeInterval;
        float launchSpeedZ = (dragEnd.y - dragStart.y) / timeInterval;

        Vector3 velocity = new Vector3 (launchSpeedX, 0, launchSpeedZ);
        ball.Launch(velocity);
        ball.hasLaunched = true;
    }

    public void MoveStart(float xNudge)
    {
        if (!ball.hasLaunched)
        {
            Vector3 translation = new Vector3(xNudge, 0f, 0f);
            this.transform.position += translation;
        }
    }
}
