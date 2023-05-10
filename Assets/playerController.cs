using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    private const float STEP_SIZE = 1f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(Input.GetAxis("Horizontal"));
        transform.position += new Vector3(STEP_SIZE * Input.GetAxis("Horizontal"), 0, STEP_SIZE * Input.GetAxis("Vertical"));
    }
}