using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(EthanAnimation))]
// Class that controls character's actions
public class Moving : MonoBehaviour {

    private EthanAnimation ethan; // An object of a class EthanAnimation
    private Animator anim; // Animator of a GameObject

	void Start () {
        ethan = GetComponent<EthanAnimation>(); // Initialization EthanAnimation
        anim = ethan.Animator; // Gaining access to Animator in the class EthanAnimation
	}

    // A character begins to run
	public void Run() {
        anim.SetTrigger("Run");
    }
    // A character turns left while he is moving
    public void RunLeft()
    {
        anim.SetTrigger("RunLeft");
    }

    // A character turns right while he is moving
    public void RunRight()
    {
        anim.SetTrigger("RunRight");
    }

    // A character turns left while he is staying
    public void TurnLeft()
    {
        anim.SetTrigger("Left");
    }

    // A character turns right while he is staying
    public void TurnRight()
    {
        anim.SetTrigger("Right");
    }

    // A character begins to stay
    public void Stay()
    {
        anim.SetTrigger("Stay");
    }

    // A character jumps
    public void Jump()
    {
        anim.SetTrigger("Jump");
    }
    // A character sit down
    public void Sit()
    {
        anim.SetTrigger("Sit");
    }

}
