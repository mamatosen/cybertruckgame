using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachineGun : MonoBehaviour
{
    Vector2 dir;
    float lineReach = 20, time;
    bool shooting = false;

    public Animator animator;
    public GameObject bulletPrefab;
    public Transform gunHole, trash;
    public LineRenderer lineRenderer;
    public Light gunlight;
    public float angleRange = 60, timeBetweenBullets = 0.2f;
    public AudioSource audioSource;

    // private

    private void Update()
    {
        PointAtMouse();

        if (Input.GetMouseButton(0))
        {
            if (!shooting) StartShooting();
            Shoot();
        }
        if (Input.GetMouseButtonUp(0))
        {
            StopShooting();
        }

        if (time < timeBetweenBullets) time += Time.deltaTime;
    }

    private void PointAtMouse()
    {
        Vector2 mouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 diff = mouse - (Vector2)gunHole.position;
        dir = diff.normalized;
        ClampAngle();
        lineRenderer.SetPosition(0, gunHole.transform.position);
        lineRenderer.SetPosition(1, (Vector2)gunHole.transform.position + (dir * lineReach));
    }

    private void ClampAngle()
    {
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        if(angle > angleRange)
        {
            dir = new Vector2(Mathf.Cos(angleRange * Mathf.Deg2Rad), Mathf.Sin(angleRange * Mathf.Deg2Rad));
        }
        else if(angle < -angleRange)
        {
            dir = new Vector2(Mathf.Cos(-angleRange * Mathf.Deg2Rad), Mathf.Sin(-angleRange * Mathf.Deg2Rad));
        }
    }

    // public

    public void Fold()
    {

    }

    public void DoneFolding()
    {

    }

    public void UnFold()
    {

    }

    public void DoneUnfold()
    {

    }

    public void StartShooting()
    {
        shooting = true;
        animator.SetBool("shooting", true);
        audioSource.Play();
        gunlight.enabled = true;
    }

    public void Shoot()
    {
        if (time >= timeBetweenBullets)
        {
            time = 0;
            GameObject bullet = Instantiate(bulletPrefab, gunHole.position, Quaternion.identity, trash);
            bullet.GetComponent<Bullet>().Shoot(dir + new Vector2((Random.value - 0.5f) * 0.02f, (Random.value - 0.5f) * 0.02f));
        }
    }

    public void StopShooting()
    {
        shooting = false;
        animator.SetBool("shooting", false);
        audioSource.Stop();
        gunlight.enabled = false;
    }
}
