using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(ChangeRotation))]
[CanEditMultipleObjects]
public class ChangeRotationEditor : Editor
{



    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        ChangeRotation c = (ChangeRotation) target;

        if(GUILayout.Button("Set min rotation"))
        {
            c.minRotation = c.transform.localRotation.eulerAngles;
        }

        if (GUILayout.Button("Set max rotation"))
        {
            c.maxRotation = c.transform.localRotation.eulerAngles;
        }

        if (GUILayout.Button("reset to min"))
        {
            c.transform.localRotation = Quaternion.Euler( c.minRotation );
        }

        if (GUILayout.Button("Invert values"))
        {
            Vector3 temp = c.minRotation;
            c.minRotation = c.maxRotation;
            c.maxRotation = temp;
        }
    }

}
