using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.UIElements.UxmlAttributeDescription;
using UnityEngine.UI;

public class WriteHeightMapToPNG : MonoBehaviour
{

    public float _SeedX = 0;
    public float _SeedY = 0;

    public float _Scale = 1;

    public int Octaves = 1;
    public ComputeShader BGS;

    public void GenerateHeightMapTexture()
    {
        RenderTexture RT = new RenderTexture(256, 256, 1);
        RT.enableRandomWrite = true;
        RT.Create();

        BGS.SetTexture(0, "Result", RT);
        BGS.SetFloat("_SeedX", _SeedX);
        BGS.SetFloat("_SeedY", _SeedY);
        BGS.SetFloat("_Scale", _Scale);
        BGS.SetInt("_NumOctaves", Octaves);



        BGS.Dispatch(0, RT.width / 8, RT.height / 8, 1);

        RenderTexture.active = RT;
        Texture2D tex2save = new Texture2D(256, 256, TextureFormat.RGB24, false);
        tex2save.ReadPixels(new Rect(0, 0, 256, 256), 0, 0);
        RenderTexture.active = null;
        DestroyImmediate(RT);
        byte[] data;
        data = tex2save.EncodeToPNG();
        System.IO.File.WriteAllBytes("Assets/Development/ShaderWorldGen/HeightMapShader/Image.png", data);
    }
}
