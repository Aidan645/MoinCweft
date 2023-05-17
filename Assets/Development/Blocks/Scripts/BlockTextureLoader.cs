using System.Collections.Generic;
using UnityEngine;

public class BlockTextureLoader
{
    public class CubeTexture
    {
        public Vector2[] SideTextureUVs, DownTextureUVs, UpTextureUVs;

        public CubeTexture(Vector2[] SideUvs, Vector2[] DownUvs, Vector2[] UpUVs)
        {
            SideTextureUVs = SideUvs;
            DownTextureUVs = DownUvs;
            UpTextureUVs = UpUVs;
        }

        public Vector2[] GetUVsAtDirection(Vector3Int Dir)
        {
            if (Dir.y == 1) return UpTextureUVs;
            if (Dir.y == -1) return DownTextureUVs;
            return SideTextureUVs;
        }
    }

    public Dictionary<int, CubeTexture> CubeTextures;
    private Dictionary<int, Vector2[]> UvDict;


    public BlockTextureLoader()
    {
        CubeTextures = new Dictionary<int, CubeTexture>();
        CalculateUVs();
        InsertBlock(BlockCollection.GRASS);
    }

    public void InsertBlock(Block block)
    {
        CubeTextures.Add(block.Id, new CubeTexture(UvDict[block.SideIndex], UvDict[block.DownIndex], UvDict[block.UpIndex]));
    }

    public void CalculateUVs()
    {
        UvDict = new Dictionary<int, Vector2[]>();

        float PNGWidth = 32f;
        float PNGHeight = 16f;
        for(int i = 0;i < PNGWidth*PNGHeight;i++)
        {
            float x =(float)(i % 32) / 32;
            float y = 1 - (Mathf.Floor((float)(i) / 32) / 16);
            float dx = 1 / PNGWidth;
            float dy = 1 / PNGHeight;
            UvDict.Add(i, new Vector2[] { new Vector2(x, y), new Vector2(x + dx, y), new Vector2(x, y - dy), new Vector2(x + dx, y - dy) });
        }
    }
}
