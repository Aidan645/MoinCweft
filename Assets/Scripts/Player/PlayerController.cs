using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float Speed = 1f;
    public float JumpForce = 10f;

    private Rigidbody rb;
    public float groundCheckDistance = 10.1f;
    public float lastYVelocity;
    // Start is called before the first frame update


    void Start()
    {
        rb = GetComponent<Rigidbody>();
        lastYVelocity = -1f;
    }

    // Update is called once per frame
    private void Update()
    {
        Tuple<int, int> Movement = GetWASDInputs();
        transform.position += transform.TransformDirection(new Vector3(Movement.Item1, 0, Movement.Item2) * Speed * Time.deltaTime);
    }
    void FixedUpdate()
    {
        //bool grounded = Physics.Raycast(transform.position, Vector3.down, groundCheckDistance);
        bool grounded = lastYVelocity <= 0 && rb.velocity.y == 0;
        lastYVelocity = rb.velocity.y;

        if (Input.GetKey(KeyCode.Space) && grounded) {
            rb.AddForce(Vector3.up * JumpForce, ForceMode.Impulse);
        }
    }

    private Tuple<int,int> GetWASDInputs()
    {
        int vertical = 0;
        int horizontal = 0;
        if (Input.GetKey(KeyCode.W)) vertical += 1;
        if (Input.GetKey(KeyCode.S)) vertical -= 1;
        if (Input.GetKey(KeyCode.D)) horizontal += 1;
        if (Input.GetKey(KeyCode.A)) horizontal -= 1;

        return new Tuple<int, int> ( horizontal, vertical);
    }
}