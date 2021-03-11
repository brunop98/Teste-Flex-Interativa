using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(AutoNameGameObjects))]
public class AutoNameGameObjectsEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        AutoNameGameObjects script = (AutoNameGameObjects) target;

        if (GUILayout.Button("Autoname game objects"))
        {
            script.Autoname();
        }

        if (GUILayout.Button("Improove UI performance"))
        {
            script.ImprooveUIPerfomence();
        }

    }
}
