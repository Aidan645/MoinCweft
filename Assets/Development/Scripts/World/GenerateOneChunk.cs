using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static WorldStructure;
using static WorldGeneration;

public class GenerateOneChunk : MonoBehaviour
{
    public GameObject worldgenerationmanager;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 6; i++)
        {
            for (int j = 0; j < 6; j++)
            {
                Chunk2 chunk = new Chunk2(i, j);
                worldgenerationmanager.GetComponent<WorldGeneration>().InitializeChunk(chunk);
            }
        }
        
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
