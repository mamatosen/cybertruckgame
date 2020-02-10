using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetAnimations : MonoBehaviour
{
    public Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void SetRunning()
    {
        animator.SetBool("going", true);
    }

    public void SetIdle()
    {
        animator.SetBool("going", false);
    }

    public void SetSpeed(float s)
    {
        animator.speed = s;
    }
}
