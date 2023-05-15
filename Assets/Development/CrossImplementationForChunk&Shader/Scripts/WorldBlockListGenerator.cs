using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class WorldBlockListGenerator
{
    public static int[,,] StoneRelief(Chunk c, Texture2D heightmap)
    {
        int csize = Chunk.CHUNK_SIZE;
        int chieght = Chunk.CHUNK_HEIGHT;
        int cx = c.ChunkXPos;
        int cz = c.ChunkZPos;
        int[,,] blocklist = new int[csize, chieght, csize];
        for (int x = 0; x < csize; x++)
        {
            for (int y = 0; y < chieght; y++)
            {
                for (int z = 0; z < csize; z++)
                {
                    int actualx = x + cx * csize;
                    int actualz = z + cz * csize;
                    Color heightmapcolor = heightmap.GetPixel(actualx, actualz);
                    if (heightmapcolor.r > 0.1f*y)
                    {
                        blocklist[x, y, z] = 1;
                    }
                }
            }
        }

        return blocklist;
    }
}