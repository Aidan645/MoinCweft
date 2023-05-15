using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static WorldBlockListGenerator;

public class ACHUNKYTEST : MonoBehaviour
{
    public Material materal;
    public Texture2D heightmap;
    int[,,] list;
    void Start()
    {
        GameObject ChunkBox = new GameObject("ChunkBox");
        for (int b = 0; b<8;b++){
            
            for (int a =0; a<8;a++){
            GameObject chonko = new GameObject("Chonko");
            chonko.transform.parent = ChunkBox.transform;
            MeshRenderer mr = chonko.AddComponent<MeshRenderer>();
            MeshFilter mf = chonko.AddComponent<MeshFilter>();
            Chunk chunk = new Chunk(a,b);
            chunk.Blocks = StoneRelief(chunk, heightmap);
            chunk.Meshify();
            mf.sharedMesh = chunk.Mesh;
            mr.material = materal;
        }
        }
        
    }
}
