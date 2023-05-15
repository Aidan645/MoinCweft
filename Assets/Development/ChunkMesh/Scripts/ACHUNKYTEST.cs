using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ACHUNKYTEST : MonoBehaviour
{
    public Material materal;
    int[,,] list;
    void Start()
    {
        Random.InitState(1293710992);
        for (int b = -6; b<6;b++){
            
            for (int a =-6; a<6;a++){
            list = new int[32, 32, 32];
            GameObject chonko = new GameObject();
            MeshRenderer mr = chonko.AddComponent<MeshRenderer>();
            MeshFilter mf = chonko.AddComponent<MeshFilter>();
            for(int i = 0; i< 32; i++){
                for(int j = 0; j< 32; j++){
                    for(int k = 0; k< 32; k++){
                        if (Random.Range(0f,1f)<(1-0.05*j)){
                        list[i,j,k] = 1;
                        }
                    
                    }
                }
            }
            Chunk chunk = new Chunk(list,a,b);
            mf.sharedMesh = chunk.Mesh;
            mr.material = materal;
        }
        }
        
    }
}
