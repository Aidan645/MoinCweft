using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(WriteBiomesToPNG))]
public class WriteBiomesToPNGEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        WriteBiomesToPNG myTarget = (WriteBiomesToPNG)target;
        if (GUILayout.Button("GeneratePNG")){
            myTarget.GenerateBiomeTexture();
        }
    }
}
