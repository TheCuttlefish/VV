using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomEditor(typeof(Vine))]
public class VineEditor : Editor
{

    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();
        Vine myScript = (Vine)target;
        if (GUILayout.Button("Grow 1")) myScript.Grow();
        if (GUILayout.Button("Grow 3")) myScript.Grow(true);

    }
    
}