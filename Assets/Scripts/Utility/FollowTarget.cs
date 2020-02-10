using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowTarget : MonoBehaviour
{
    public float duration = 1;
    public Transform target;

    private float threshold = 0.1f;

    private void Update()
    {
        Vector2 diff = target.position - transform.position;

        if(diff.magnitude > threshold)
        {
            transform.Translate(diff * Time.deltaTime / duration);
        }
    }
}
