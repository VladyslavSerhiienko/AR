using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// With this class character puts his hands up
public class HandsUp : MonoBehaviour {

    private Animator animator; // Animator of a GameObject

    private int touchCount = 0; // Count of clicks

    private float maxTime = 0.7f; // Acceptable time between clicks
    private float timer = 0; // Time between clicks

    private bool IsLimit = false; // Сhecking a time range between clicks

    void Start()
    {
        animator = GetComponent<Animator>(); // Initialization animator of a GameObject
    }

    void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            timer = 0; // Start timer
            IsLimit = true; // Make a time range allowable
            if (IsLimit) 
            {
                touchCount++; 
            }
            if (touchCount == 5) 
            {
                animator.SetTrigger("HandsUp"); // Set the trigger "HandsUp" and a character puts hands up
                touchCount = 0;
            }
        }

        Timer(); // Check a time range between clicks
    }

    private void Timer()
    {
        if (timer <= maxTime) // if time between clicks is less than acceptable time
        {
            timer += Time.deltaTime;
            IsLimit = true;
        }
        if (timer > maxTime) // if time between clicks is more than acceptable time
        {
            touchCount = 0;
            IsLimit = false;
            timer = 0;
        }
    }
}
