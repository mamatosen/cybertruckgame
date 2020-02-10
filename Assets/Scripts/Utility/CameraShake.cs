using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    Vector2 dir, nextPlace, basePos;
    bool shaking, goingBack;
    int times;
    float impact, distanceThresh = 30;

    public bool shake;
    public float size = 1, duration = 0.5f;
    public int count = 3;

    private void Update()
    {
        if (shake)
        {
            ShakeIt(distanceThresh);
        }

        if (shaking)
        {
            Vector2 diff = nextPlace - (Vector2)transform.localPosition;
            if(diff.magnitude > 0.1f)
            {
                transform.localPosition += (Vector3)(diff * Time.deltaTime / (duration / count / 2));
            }
            else
            {
                if (!goingBack)
                {
                    nextPlace = basePos;
                    goingBack = true;
                }
                else
                {
                    times--;
                    goingBack = false;
                    if(times > 0)
                    {
                        GenNextPlace();
                    }
                    else
                    {
                        shaking = false;
                        transform.localPosition = new Vector3(basePos.x, basePos.y, transform.localPosition.z);
                    }
                }
            }
        }
    }

    public void ShakeIt(float distance)
    {
        shake = false;
        impact = (distanceThresh - distance) / distanceThresh;
        print(impact);
        if (impact < 0) impact = 0;

        if (impact != 0) {
            if (!shaking)
            {
                shaking = true;
                basePos = transform.localPosition;
                times = count;
                GenNextPlace();
            }
        }
    }

    private void GenNextPlace()
    {
        nextPlace = (Vector2)transform.localPosition + new Vector2(Random.value - 0.5f, Random.value - 0.5f).normalized * size * impact;
    }
}
