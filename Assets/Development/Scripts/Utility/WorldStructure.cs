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
    public class Chunk2
    {
        public int Chunksize = 16;
        public ChunkCoordinates Position;
        public float[][] HeightMap;
        public Chunk2(int x, int y)
        {
            Position = new ChunkCoordinates(x,y);
            GenerateHeightMap();
        }
        public void GenerateHeightMap()
        {
            // generate heightmap
            HeightMap = new float[Chunksize][];
            for (int i = 0; i< Chunksize; i++)
            {
                float[] floats = new float[Chunksize];
                for (int j = 0; j < Chunksize; j++)
                {
                    floats[j] += Mathf.Pow(Mathf.PerlinNoise(1.234f* 0.01f * (i + Position.x * Chunksize)+65, 0.01f * 1.234f * (j + Position.y * Chunksize)+19),4);
                    floats[j] += 0.2f*Mathf.PerlinNoise(0.03f*4.32442f*(i+Position.x*Chunksize)+1200, 0.03f*6.123912f*(j +Position.y*Chunksize)+90);
                    floats[j] += 0.2f*Mathf.PerlinNoise(0.03f * 4.32442f * (i + Position.x * Chunksize) + 544, 0.03f * 6.123912f * (j + Position.y * Chunksize) + 1600);
                    floats[j] += 0.1f*Mathf.PerlinNoise(0.1f * 4.32442f * (i + Position.x * Chunksize)+40, 0.1f * 6.123912f * (j + Position.y * Chunksize)+30);
                    floats[j] /= 1.3f;
                }
                HeightMap[i] = floats;
            }
        }
    }

}
