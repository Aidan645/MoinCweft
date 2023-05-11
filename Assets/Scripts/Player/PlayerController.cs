using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float Speed = 1f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Tuple<int,int> Movement = GetWASDInputs();
        transform.position += transform.TransformDirection(new Vector3(Movement.Item1, 0, Movement.Item2) * Speed * Time.deltaTime);
    }

    private Tuple<int,int> GetWASDInputs()
    {
        int vertical = 0;
        int horizontal = 0;
        if (Input.GetKey(KeyCode.W))
        {
            vertical += 1;
        }
        if (Input.GetKey(KeyCode.S))
        {
            vertical -= 1;
        }
        if (Input.GetKey(KeyCode.D))
        {
            horizontal += 1;
        }
        if (Input.GetKey(KeyCode.A))
        {
            horizontal -= 1;
        }
        return new Tuple<int, int> ( horizontal, vertical);
    }
}