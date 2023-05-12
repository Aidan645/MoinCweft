using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static WorldStructure;

public class WorldGeneration : MonoBehaviour
{
    public Dictionary<string, GameObject> BlockDict;
    public void Start()
    {
        GenerateBlockDict();
    }
    public void InitializeChunk(Chunk chunk)
    {
        for (int i = 0; i < chunk.Chunksize; i++)
        {
            for (int j = 0; j < chunk.Chunksize; j++)
            {
                PlaceBlock("Grass", i+chunk.Position.x*chunk.Chunksize, (int)Mathf.Floor(10*chunk.HeightMap[i][j]),j+chunk.Position.y*chunk.Chunksize);
                for (int k = 0; k < (int)Mathf.Floor(10 * chunk.HeightMap[i][j]); k++)
                {
                    PlaceBlock("Dirt", i + chunk.Position.x * chunk.Chunksize, k, j + chunk.Position.y * chunk.Chunksize);
                }
            }
        }
    }

    public void PlaceBlock(string blockname, int x, int y, int z){
        Instantiate(BlockDict[blockname], new Vector3(x, y, z), Quaternion.identity);
    }
    public void PlaceBlock(string blockname, int x, int y, int z, Transform parent)
    {
        Instantiate(BlockDict[blockname], new Vector3(x, y, z), Quaternion.identity, parent);
    }
    public void GenerateBlockDict()
    {
        BlockDict = new Dictionary<string, GameObject>()
        {
            { "Grass",Resources.Load("Blocks/GrassBlock") as GameObject },
            { "Dirt",Resources.Load("Blocks/DirtBlock") as GameObject}
        };
    }
}
