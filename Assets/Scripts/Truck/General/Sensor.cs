using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sensor : MonoBehaviour
{
    int count;

    public bool active;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        count++;
        if (count > 0) active = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        count--;
        if (count <= 0) { 
            active = false;
            count = 0;
        }
    }
}
