using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockTextureLoader : MonoBehaviour
{
    public class CubeTexture
    {
        public Sprite SideTexture, DownTexture, UpTexture;

        public Vector2[] GetUVsAtDirection(Vector3Int Dir)
        {
            if (Dir.y == 1) return UpTexture.uv;
            if (Dir.y == -1) return DownTexture.uv;
            return SideTexture.uv;
        }
    }

    CubeTexture[] CubeTextures;
    public Dictionary<int, CubeTexture> Textures;

    public void Start()
    {
        Textures = new Dictionary<int, CubeTexture>();

        for(int i = 0;i < CubeTextures.Length;i++)
        {
            Textures.Add(i + 1, CubeTextures[i]);
        }
    }
}
