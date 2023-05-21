using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class WorldBlockListGenerator
{
    private static Color[] biomecolors = new Color[]{
        new Color(0.04f, 0.08f, 0.04f, 1f),
        new Color(0.1f, 0.298f, 0.1f, 1f),
        new Color(1f, 1f, 0.3f, 1f),
        new Color(0.298f, 1f, 0.298f, 1f)
    };
    private static Dictionary<Color,int[]> biomedict = new Dictionary<Color,int[]>(){
        {biomecolors[0], new int[]{6,3}}, //jng
        {biomecolors[1], new int[]{2,3}}, //forrest
        {biomecolors[2], new int[]{12,12}}, //desert
        {biomecolors[3], new int[]{172,1}} // plains
    };
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

    public static int[][][] BiomeCover(Chunk c, Texture2D biomemap){
        int[][][] blocklist = c.Blocks;
        int csize = Chunk.CHUNK_SIZE;
        int chieght = Chunk.CHUNK_HEIGHT;
        int cx = c.ChunkXPos;
        int cz = c.ChunkZPos;
        for (int x = 0; x < csize; x++)
        {
            for (int z = 0; z < csize; z++)
            {
                for (int y = chieght-1; y >= 0; y--)
                {
                    if (blocklist[x][y][z] == 1){

                        int actualx = x + cx * csize;
                        int actualz = z + cz * csize;
                        Color biomecolor = DecideColor(biomemap.GetPixel(actualx, actualz));
                        blocklist[x][y][z] = biomedict[biomecolor][0];
                        for (int i = 1; i < 3; i++)
                        {
                            blocklist[x][Mathf.Max(y-i,0)][z] = biomedict[biomecolor][1];
                        }                        
                        break;
                    }
                }
            }
        }
        return blocklist;
    }
    public static Color DecideColor(Color approx){
        foreach (Color color in biomecolors){
            if(CompareColors(color,approx)){
                return color;
            }
        }
        return new Color(0,0,0,0);
    }

    public static bool CompareColors(Color accurate,Color approx){
        if ((accurate.r < approx.r + 0.05f) && (accurate.r > approx.r - 0.05f) && (accurate.g < approx.g + 0.05f) && (accurate.g > approx.g - 0.05f) && (accurate.b < approx.b + 0.05f) && (accurate.b > approx.b -0.05f)){
            return true;
        }
        return false;
    }
}