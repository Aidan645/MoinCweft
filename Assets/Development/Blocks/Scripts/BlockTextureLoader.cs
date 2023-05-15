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

    public CubeTexture[] CubeTextures;

}
