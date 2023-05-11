using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class GenerateField : MonoBehaviour
{
    public int size = 16;
    public GameObject fieldblock;

    void Start()
    {
        for (int i = 0; i < size; i++) // for x
        {
            for(int j = 0; j < size; j++) // for z
            {
                // make block prefab as child of this gameobject at x,0,z with base rotation.
                GameObject fieldblockthingy = Instantiate(fieldblock,gameObject.transform.TransformPoint(new Vector3(i-size/2, 0, j-size/2)), Quaternion.identity, gameObject.transform);
            }
        }
    }
}
