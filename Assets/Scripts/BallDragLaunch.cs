using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(Ball))]
public class BallDragLaunch : MonoBehaviour {

    private Ball ball;
    private Vector3 dragStart, dragEnd;
    private float startTime, endTime;


    void Start () {
        ball = GetComponent<Ball>();
	}

    private void Update()
    {
        if (!ball.hasLaunched)
        {
            transform.position = new Vector3(Mathf.Clamp(transform.position.x, -42.15f, 42.15f), transform.position.y, transform.position.z);
        }
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
            float xPos = Mathf.Clamp(ball.transform.position.x + xNudge, -42.15f, 42.15f);
            float yPos = ball.transform.position.y;
            float zPos = ball.transform.position.z;

            ball.transform.position = new Vector3(xPos, yPos, zPos);
        }
    }
}
