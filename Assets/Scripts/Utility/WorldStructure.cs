using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldStructure
{
    public struct ChunkCoordinates
    {
        public int x;
        public int y;
        public ChunkCoordinates(int xd, int yd)
        {
            x = xd;
            y = yd;
        }
    }
    public class Chunk
    {
        public int Chunksize = 16;
        public ChunkCoordinates Position;
        public float[][] HeightMap;
        public Chunk(int x, int y)
        {
            Position = new ChunkCoordinates(x,y);
            GenerateChunk();
        }
        public void GenerateChunk()
        {
            // generate heightmap
            HeightMap = new float[Chunksize][];
            for (int i = 0; i< Chunksize; i++)
            {
                float[] floats = new float[Chunksize];
                for (int j = 0; j < Chunksize; j++)
                {
                    floats[j] = Mathf.PerlinNoise(i, j);
                }
                HeightMap[i] = floats;
            }
        }
    }

}
