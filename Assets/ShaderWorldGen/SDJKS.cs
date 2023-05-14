using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.UIElements.UxmlAttributeDescription;
using UnityEngine.UI;

public class SDJKS : MonoBehaviour
{

    public float _SeedX = 0;
    public float _SeedY = 0;

    public float _RainScale = 1;
    public float _RainMult = 1;

    public float _TempScale = 1;
    public float _TempMult = 1;

    public float _NutScale = 1;
    public float _NutMult = 1;

    public int Octaves = 1;
    public ComputeShader WGS;

    public void GenerateBiomeTexture()
    {
        RenderTexture RT = new RenderTexture(256, 256, 1);
        RT.enableRandomWrite = true;
        RT.Create();

        WGS.SetTexture(0, "Result", RT);
        WGS.SetFloat("_SeedX", _SeedX);
        WGS.SetFloat("_SeedY", _SeedY);
        WGS.SetFloat("_RainMult", _RainMult);
        WGS.SetFloat("_RainScale", _RainScale);
        WGS.SetFloat("_TempMult", _TempMult);
        WGS.SetFloat("_TempScale", _TempScale);
        WGS.SetFloat("_NutScale", _NutScale);
        WGS.SetFloat("_NutMult", _NutMult);
        WGS.SetInt("_NumOctaves", Octaves);



        WGS.Dispatch(0, RT.width / 8, RT.height / 8, 1);

        RenderTexture.active = RT;
        Texture2D tex2save = new Texture2D(256, 256, TextureFormat.RGB24, false);
        tex2save.ReadPixels(new Rect(0, 0, 256, 256), 0, 0);
        RenderTexture.active = null;
        DestroyImmediate(RT);
        byte[] data;
        data = tex2save.EncodeToPNG();
        System.IO.File.WriteAllBytes("Assets/ShaderWorldGen/Image.png", data);
    }
}
