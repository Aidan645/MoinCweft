using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(SDJKS))]
public class SDJKSEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        SDJKS myTarget = (SDJKS)target;
        if (GUILayout.Button("GeneratePNG")){
            myTarget.GenerateBiomeTexture();
        }
    }
}
