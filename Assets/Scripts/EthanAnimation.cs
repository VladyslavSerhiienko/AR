using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Moving))]
// Class that controls event recognition
public class EthanAnimation : MonoBehaviour {

    private Animator animator; // Animator of a GameObject
    private Moving move; // An object of a class Moving

    private float maxTime = 0.5f; // Acceptable time between swipes
    private float minDistance = 50; // Minimum swipe distance
    private float startTime; // Time when a swipe started
    private float endTime; // Time when a swipe finished
    private float swipeDistance; // A swipe distance
    private float swipeTime; // A swipe time
    private float timer = 10f; // Acceptable time 

    private bool flagRun = false; // Flag that check moving a charcter or no
    private bool flagSit = true; // Flag that activate timer 

    private Vector3 startPos; // Start swipe's position 
    private Vector3 endPos; // End swipe's position 

    //Property that return value of variable Animator
    public Animator Animator
    {
        get
        {
            return this.animator;
        }
    }

	void Start () {
        animator = GetComponent<Animator>(); // Initialization Animator
        move = GetComponent<Moving>(); // Initialization Moving
	}
	
	void Update () {
        ComputerControl();
        MobileControl();
        Timer();
	}

    // Function that tracks the actions on the computer
    private void ComputerControl()
    {
        if (Input.GetKeyDown("w")) // To run
        {
            move.Run();
            flagRun = true;
            timer = 10f;
        }

        if (Input.GetKeyDown("a") && flagRun) // Turn left in motion
        {
            move.RunLeft();
            timer = 10f;
        }

        if (Input.GetKeyDown("d") && flagRun) // Turn right in motion
        {
            move.RunRight();
            timer = 10f;
        }

        if (Input.GetKeyDown("a") && !flagRun) // Turn left on the spot
        {
            move.TurnLeft();
            timer = 10f;
            flagSit = true; 
        }

        if (Input.GetKeyDown("d") && !flagRun) // Turn right on the spot
        {
            move.TurnRight();
            timer = 10f;
            flagSit = true;
        }

        if (Input.GetKeyDown("s")) // To stay
        {
            move.Stay();
            flagRun = false;
            timer = 10f;
            flagSit = true;
        }

        if (Input.GetKeyDown("space") && flagRun) // Jump in motion
        {
            move.Jump();
            timer = 10f;
            flagSit = false;
        }

        if (Input.GetKeyDown("space") && !flagRun) // Jump from the spot
        {
            move.Jump();
            timer = 10f;
            flagSit = true;
        }
    }

    // Function that tracks the actions on the mobile device
    private void MobileControl()
    {
        if (Input.touchCount > 0)
        {
            if (Input.touchCount == 1)
            {
                Touch touch = Input.GetTouch(0); // Getting touch of the screen

                if (touch.phase == TouchPhase.Began) // Swipe's start
                {
                    startTime = Time.time;
                    startPos = touch.position;
                }
                else if (touch.phase == TouchPhase.Ended) // Swipe's end
                {
                    endTime = Time.time;
                    endPos = touch.position;
                    swipeDistance = (endPos - startPos).magnitude; // Count of swipe's distance
                    swipeTime = endTime - startTime; // Count of swipe's time

                    if (swipeTime <= maxTime && swipeDistance >= minDistance)
                    {
                        swipe();
                    }
                }
            }
            if (Input.touchCount == 2)
            {
                if (Input.GetTouch(0).phase == TouchPhase.Began && Input.GetTouch(1).phase == TouchPhase.Began) // If only touched twice
                {
                    if (flagRun)
                    {
                        move.Jump();
                        timer = 10f;
                        flagSit = false;
                    }
                    if (!flagRun)
                    {
                        move.Jump();
                        timer = 10f;
                        flagSit = true;
                    }
                }
            }
        }
    }
    // Function that controls swipes on the screen
    private void swipe()
    {
        Vector2 distance = endPos - startPos;

        if (Mathf.Abs(distance.x) < Mathf.Abs(distance.y))
        {
            if (distance.y > 0)
            {
                move.Run();
                flagRun = true;
                timer = 10f;
            }
            if (distance.y < 0)
            {
                move.Stay();
                flagRun = false;
                timer = 10f;
                flagSit = true;
            }
        }
        else if (Mathf.Abs(distance.x) > Mathf.Abs(distance.y))
        {
            if (distance.x > 0 && !flagRun)
            {
                move.TurnRight();
                timer = 10f;
                flagSit = true;
            }
            if (distance.x < 0 && !flagRun)
            {
                move.TurnLeft();
                timer = 10f;
                flagSit = true; 
            }
            if (distance.x > 0 && flagRun)
            {
                move.RunRight();
                timer = 10f;
            }
            if (distance.x < 0 && flagRun)
            {
                move.RunLeft();
                timer = 10f;
            }
        }
    }

    private void Timer()
    {
        if (flagSit == true && timer > 0)
        {
            timer -= Time.deltaTime;
        }

        if (timer <= 0f)
        {
            move.Sit();
            timer = 10f;
            flagSit = false;
            return;
        }
    }
}
