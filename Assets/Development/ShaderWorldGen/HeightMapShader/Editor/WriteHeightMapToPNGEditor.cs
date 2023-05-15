using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(WriteHeightMapToPNG))]
public class WriteHeightMapToPNGEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        WriteHeightMapToPNG myTarget = (WriteHeightMapToPNG)target;
        if (GUILayout.Button("GeneratePNG")){
            myTarget.GenerateHeightMapTexture();
        }
    }
}
