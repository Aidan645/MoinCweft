using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lookAround : MonoBehaviour
{
    // Start is called before the first frame update
    public float MOUSE_SPEED = 500f;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.eulerAngles += MOUSE_SPEED * Time.deltaTime * new Vector3(-Input.GetAxis("Mouse Y"), Input.GetAxis("Mouse X"), 0);
    }
}
