using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandsUp : MonoBehaviour {

    public GameObject character; // объект 
    private Animator animator; // аниматор объекта

    private int touchCount = 0; // кол-во нажатий

    private float maxTime = 0.7f; // допустимое время между нажатиями
    private float timer = 0; //время между нажатиями 

    private bool IsLimit = false;

    void Start()
    {
        animator = character.GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            timer = 0; // запускаем таймер
            IsLimit = true;
            if (IsLimit) // если диапазон времени между нажатиями допустим
            {
                touchCount++;
            }
            if (touchCount == 5)
            {
                animator.SetTrigger("HandsUp");
                touchCount = 0;
            }
        }
        // Таймер
        if (timer <= maxTime)
        {
            timer += Time.deltaTime;
            IsLimit = true;
        }
        if (timer > maxTime)
        {
            touchCount = 0;
            IsLimit = false;
            timer = 0;
        }
    }
}
