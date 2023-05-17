using UnityEngine;

public class ACHUNKYTEST : MonoBehaviour
{
    public Material materal;
    int[,,] list;
    void Start()
    {
        
        int size = 16;
        Random.InitState(1293710992);
        for (int b = -6; b<6;b++){
            
            for (int a =-6; a<6;a++){
            list = new int[size, size, size];
            GameObject chonko = new GameObject();
            MeshRenderer mr = chonko.AddComponent<MeshRenderer>();
            MeshFilter mf = chonko.AddComponent<MeshFilter>();
            for(int i = 0; i< size; i++){
                for(int j = 0; j< size; j++){
                    for(int k = 0; k< size; k++){
                        if (Random.Range(0f,1f)<(1-0.05*j)){
                        list[i,j,k] = BlockCollection.GRASS.Id;
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
