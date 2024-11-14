using UnityEditor;
using UnityEngine;
using System;
using System.Reflection;

[CustomEditor(typeof(MonoBehaviour), true)]
public class CustomInspectorButton : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        MonoBehaviour monoBehavior = (MonoBehaviour)target;

        Type type = monoBehavior.GetType();

        foreach (MethodInfo method in type.GetMethods(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic))
        {
            if (!Attribute.IsDefined(method, typeof(InspectorButtonAttribute))) continue;
            
            InspectorButtonAttribute attribute = (InspectorButtonAttribute)Attribute.
                GetCustomAttribute(method, typeof(InspectorButtonAttribute));

            if (GUILayout.Button(attribute.Name))
            {
                if (!Application.isPlaying && !attribute.InEditMode) continue;

                method.Invoke(monoBehavior, null);
            }
        }
    }
}
