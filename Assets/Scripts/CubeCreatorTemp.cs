using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeCreatorTemp : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<MeshFilter>().sharedMesh = MeshUtils.UnitCube;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
