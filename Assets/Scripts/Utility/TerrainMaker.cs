using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainMaker : MonoBehaviour
{
    public GameObject ground, wall;
    public Transform truck;

    Transform curPlatform;

    private void Start()
    {
        MakePlatform();
    }

    private void MakePlatform()
    {
        curPlatform = Instantiate(ground, new Vector3(truck.position.x + 50, 0, 0), Quaternion.identity, transform).transform;
    }

    private void Update()
    {
        if(truck.position.x > curPlatform.position.x)
        {
            MakePlatform();
        }
    }
}
