using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class VehicleControl : MonoBehaviour
{
    Rigidbody2D rb;
    bool grounded;

    public float forwAcc, forwMaxVel, backwAcc, backwMaxVel, rotationAcc, baseZoom, maxZoom, zoomSpeed = 1;
    public SetAnimations carAnimations;
    public Camera cam;
    public Sensors sensors;

    public void ClampSpeed() {
        rb.velocity = new Vector2(
            Mathf.Clamp(rb.velocity.x, -backwMaxVel, forwMaxVel),
            rb.velocity.y
        );
    }

    public void Accelerate()
    {
        if (grounded)
        {
            rb.velocity = rb.velocity + (Vector2)transform.right * forwAcc * Time.deltaTime;
            ClampSpeed();
            carAnimations.SetRunning();
        }
    }

    public void DeAccelerate()
    {
        if (grounded)
        {
            rb.velocity = rb.velocity + (Vector2)transform.right * -backwAcc * Time.deltaTime;
            ClampSpeed();
            carAnimations.SetRunning();
        }
    }

    public void RotateRight()
    {

    }

    public void RotateLeft()
    {

    }

    public void RotateBack()
    {
        float angle = transform.rotation.eulerAngles.z;
        if (angle > -90 && angle < 90)
        {
            transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z - angle * Time.deltaTime);
        }
    }

    // private

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        Accelerate();
        if (Input.GetMouseButton(1))
        {
            rb.velocity += new Vector2(0, 1);
        }
        RotateBack();
        CheckSpeed();
        ChangeZoom();
        CheckSensors();
    }

    private void CheckSensors()
    {
        if (sensors.flip.active)
        {
            Flip();
        }
        grounded = sensors.ground;
    }

    public void Flip()
    {
        transform.Rotate(new Vector3(0, 0, 180));
        transform.Translate(new Vector3(0, 1, 0));
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

    private void ChangeZoom()
    {
        float mag = rb.velocity.magnitude;
        if(mag > 5)
        {
            cam.orthographicSize += Time.deltaTime * zoomSpeed * mag;
        }
        else
        {
            cam.orthographicSize -= Time.deltaTime * zoomSpeed;
        }

        cam.orthographicSize = Mathf.Clamp(cam.orthographicSize, baseZoom, maxZoom);
    }
}
