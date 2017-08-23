using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EthanAnimation : MonoBehaviour {

    public GameObject player;
    private Animator animator;

    private float maxTime = 0.5f; 
    private float minDistance = 50;
    private float startTime;
    private float endTime;
    private float swipeDistance;
    private float swipeTime;
    private float timer = 10f;

    private bool flagRun = false;
    private bool flagSit = true;

    private Vector3 startPos;
    private Vector3 endPos;

	void Start () {
        animator = player.GetComponent<Animator>();
	}
	
	void Update () {

        if (Input.GetKeyDown("w")) { // бег
            animator.SetTrigger("Run");
            flagRun = true; 
            timer = 10f;
        }

        if (Input.GetKeyDown("a") && flagRun) { // если бежит и поворачивает влево
            animator.SetTrigger("RunLeft");
            timer = 10f;
        }

        if (Input.GetKeyDown("d") && flagRun) { // если бежит и поворачивает вправо
            animator.SetTrigger("RunRight");
            timer = 10f; 
        }

        if (Input.GetKeyDown("a") && !flagRun) { // если поворачивает на месте влево
            animator.SetTrigger("Left");
            timer = 10f;
            flagSit = true; // активация таймера
        }

        if (Input.GetKeyDown("d") && !flagRun) { // если поворачивает на месте вправо
            animator.SetTrigger("Right");
            timer = 10f;
            flagSit = true;
        }

        if (Input.GetKeyDown("s")) { 
            animator.SetTrigger("Stay"); 
            flagRun = false;
            timer = 10f;
            flagSit = true;
        }

        if (Input.GetKeyDown("space") && flagRun) { 
            animator.SetTrigger("Jump");
            timer = 10f;
            flagSit = false;
        }

        if (Input.GetKeyDown("space") && !flagRun) // прыжок с места
        {
            animator.SetTrigger("Jump");
            timer = 10f;
            flagSit = true;
        }

        //--------------------------------------------МОБ-------------------------------------------------------------------------------------

        if (Input.touchCount >0 )
        {
            if (Input.touchCount == 1)
            {
                Touch touch = Input.GetTouch(0);

                if (touch.phase == TouchPhase.Began)
                {
                    startTime = Time.time;
                    startPos = touch.position;
                }
                else if (touch.phase == TouchPhase.Ended)
                {
                    endTime = Time.time;
                    endPos = touch.position;
                    swipeDistance = (endPos - startPos).magnitude;
                    swipeTime = endTime - startTime;

                    if (swipeTime <= maxTime && swipeDistance >= minDistance)
                    {
                        swipe();
                    }
                }
            }
            if (Input.touchCount == 2)
            {
                if (Input.GetTouch(0).phase == TouchPhase.Began && Input.GetTouch(1).phase == TouchPhase.Began)
                {
                    if (flagRun)
                    {
                        animator.SetTrigger("Jump");
                        timer = 10f;
                        flagSit = false;
                    }
                    if (!flagRun)
                    {
                        animator.SetTrigger("Jump");
                        timer = 10f;
                        flagSit = true;
                    }
                }
            }
        }

        // Таймер 
        if (flagSit == true && timer > 0)
        {
            timer -= Time.deltaTime;
        }

        if (timer <= 0f)
        {
            animator.SetTrigger("Sit");
            timer = 10f;
            flagSit = false;
            return;
        }
	}
    public void swipe()
    {
        Vector2 distance = endPos - startPos;

        if (Mathf.Abs(distance.x) < Mathf.Abs(distance.y))
        {
            if (distance.y > 0)
            {
                // Up
                animator.SetTrigger("Run");
                flagRun = true;
                timer = 10f;
            }
            if (distance.y < 0)
            {
                // Down
                animator.SetTrigger("Stay");
                flagRun = false;
                timer = 10f;
                flagSit = true;
            }
        }
        else if (Mathf.Abs(distance.x) > Mathf.Abs(distance.y))
        {
            if (distance.x > 0 && !flagRun)
            {
                // Right
                animator.SetTrigger("Right");
                timer = 10f;
                flagSit = true;
            }
            if (distance.x < 0 && !flagRun)
            {
                // Left
                animator.SetTrigger("Left");
                timer = 10f;
                flagSit = true; // активация таймера
            }
            if (distance.x > 0 && flagRun)
            {
                // RunRight
                animator.SetTrigger("RunRight");
                timer = 10f; 
            }
            if (distance.x < 0 && flagRun)
            {
                // RunLeft
                animator.SetTrigger("RunLeft");
                timer = 10f;
            }
        }
    }
}
