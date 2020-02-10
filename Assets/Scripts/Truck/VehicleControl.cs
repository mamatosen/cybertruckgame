using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class VehicleControl : MonoBehaviour
{
    Rigidbody2D rb;

    public float forwAcc, forwMaxVel, backwAcc, backwMaxVel, rotationAcc;
    public SetAnimations carAnimations;

    public void ClampSpeed() {
        rb.velocity = new Vector2(
            Mathf.Clamp(rb.velocity.x, -backwMaxVel, forwMaxVel),
            rb.velocity.y
        );
    }

    public void Accelerate()
    {
        rb.velocity = rb.velocity + new Vector2(forwAcc, 0) * Time.deltaTime;
        ClampSpeed();
        carAnimations.SetRunning();
    }

    public void DeAccelerate()
    {
        rb.velocity = rb.velocity + new Vector2(-backwAcc, 0) * Time.deltaTime;
        ClampSpeed();
        carAnimations.SetRunning();
    }

    public void RotateRight()
    {

    }

    public void RotateLeft()
    {

    }

    // private

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        CheckSpeed();
    }

    private void CheckSpeed()
    {
        float vxAbs = Mathf.Abs(rb.velocity.x);

        if(vxAbs > 0)
        {
            carAnimations.SetSpeed(vxAbs);
        }
        else
        {
            carAnimations.SetIdle();
        }
    }
}
