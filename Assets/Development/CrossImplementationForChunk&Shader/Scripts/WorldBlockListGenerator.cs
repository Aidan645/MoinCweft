using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class WorldBlockListGenerator
{
    public static int[][][] StoneRelief(Chunk c, Texture2D heightmap)
    {
        int csize = Chunk.CHUNK_SIZE;
        int chieght = Chunk.CHUNK_HEIGHT;
        int cx = c.ChunkXPos;
        int cz = c.ChunkZPos;
        int[][][] blocklist = new int[csize][][];
        for (int x = 0; x < csize; x++)
        {
            blocklist[x] = new int[chieght][];
            for (int y = 0; y < chieght; y++)
            {
                blocklist[x][y] = new int[csize];
                for (int z = 0; z < csize; z++)
                {
                    int actualx = x + cx * csize;
                    int actualz = z + cz * csize;
                    Color heightmapcolor = heightmap.GetPixel(actualx, actualz);
                    if (heightmapcolor.r > 0.1f*y)
                    {
                        blocklist[x][y][z] = 1;
                    }
                }
            }
        }

        return blocklist;
    }

    public static int[][][] DirtGround(Chunk c, Texture2D biomemap){
        int[][][] blocklist = c.Blocks;
        
        for (int x = 0; x < Chunk.CHUNK_SIZE; x++)
        {
            for (int z = 0; z < Chunk.CHUNK_SIZE; z++)
            {
                for (int y = Chunk.CHUNK_HEIGHT-1; y >= 0; y--)
                {
                    if (blocklist[x][y][z] == 1){
                        blocklist[x][y][z] = 2;
                        for (int i = 1; i < 3; i++)
                        {
                            blocklist[x][Mathf.Max(y-i,0)][z] = 3;
                        }                        
                        break;
                    }
                }
            }
        }
        return blocklist;
    }
}