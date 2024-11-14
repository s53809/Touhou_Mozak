using System;
using System.Reflection;
using System.IO;
using System.CodeDom;
using System.CodeDom.Compiler;
using Microsoft.CSharp;
using UnityEngine;
using System.Security.Permissions;
using System.Resources;
using UnityEditor;
using Unity.VisualScripting;
using UnityEditor.Compilation;
using System.Collections;

[ExecuteInEditMode]
public class UIGenerator : MonoBehaviour
{
    private CodeCompileUnit targetUnit;
    private CodeTypeDeclaration targetClass;

    [InspectorButton("Generate View Code", true)]
    private void StartSequence()
    {
        GenerateCode(
            Path.Combine(
            Application.dataPath, "Scripts", "UI", gameObject.name, $"{gameObject.name}View.cs"));
    }

    private void GenerateCode(String pFileName)
    {
        //Generate Class
        targetUnit = new CodeCompileUnit();
        CodeNamespace samples = new CodeNamespace();
        targetClass = new CodeTypeDeclaration($"{gameObject.name}View");
        targetClass.IsClass = true;
        targetClass.TypeAttributes = TypeAttributes.Public;
        targetClass.IsPartial = true;
        targetClass.BaseTypes.Add("ViewBase");
        samples.Types.Add(targetClass);
        targetUnit.Namespaces.Add(samples);

        //Generate Member
        CodeMemberField[] fields = GenerateMember();
        foreach (CodeMemberField field in fields)
            targetClass.Members.Add(field);

        //Generate Code
        CodeDomProvider provider = CodeDomProvider.CreateProvider("CSharp");
        CodeGeneratorOptions options = new CodeGeneratorOptions();
        options.BracingStyle = "C";
        String newDirectory = pFileName.Replace($"{gameObject.name}View.cs", "");

        if (!Directory.Exists(newDirectory))
            Directory.CreateDirectory(newDirectory);

        using (StreamWriter sourceWriter = new StreamWriter(pFileName))
            provider.GenerateCodeFromCompileUnit(targetUnit, sourceWriter, options);

        AssetDatabase.Refresh();

        Invoke(nameof(FinishGenerateCode), 0.5f);
    }

    void FinishGenerateCode()
    {
        gameObject.AddComponent(Type.GetType($"{gameObject.name}View"));
        DestroyImmediate(gameObject.GetComponent<UIGenerator>());
    }

    private CodeMemberField[] GenerateMember()
    {
        Int32 childCount = gameObject.transform.childCount;
        CodeMemberField[] temp = new CodeMemberField[childCount];

        for(Int32 i = 0; i < childCount; i++)
        {
            GameObject childObj = gameObject.transform.GetChild(i).gameObject;
            CodeMemberField field = new CodeMemberField();
            field.Attributes = MemberAttributes.Public;
            field.Name = childObj.name;
            field.Type = FindUIComponent(childObj);
            temp[i] = field;
        }

        return temp;
    }

    private CodeTypeReference FindUIComponent(GameObject obj)
    {
        Component comp = new Component();
        foreach(Type type in UITypes.types)
        {
            if(obj.TryGetComponent(type, out comp))
            {
                return new CodeTypeReference(comp.GetType());
            }
        }
        throw new NotImplementedException();
    }
}