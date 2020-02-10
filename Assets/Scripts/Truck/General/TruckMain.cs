using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TruckMain : MonoBehaviour
{
    [SerializeField]
    public List<KeyStroke> inputs = new List<KeyStroke>();

    private void CheckInput()
    {
        foreach(KeyStroke input in inputs)
        {
            input.Check();
        }
    }

    private void Update()
    {
        CheckInput();
    }
}
