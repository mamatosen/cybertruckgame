using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightDimmer : MonoBehaviour
{
    public Light light;
    public float duration = 0.5f;

    private void Update()
    {
        if(light.intensity > 0)
        {
            light.intensity -= Time.deltaTime / duration;
        }
    }
}
