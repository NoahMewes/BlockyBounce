using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class ColozMatInspector : ShaderGUI
{

    public override void OnGUI(MaterialEditor materialEditor, MaterialProperty[] properties)
    {

        //foreach (MaterialProperty property in properties){
        //    materialEditor.ShaderProperty(property, property.displayName);
        //}
        MaterialProperty _MainTexture = ShaderGUI.FindProperty("_MainTexture", properties);

        MaterialProperty _ColorForward = ShaderGUI.FindProperty("_ColorForward", properties);
        MaterialProperty _UseGradient_F = ShaderGUI.FindProperty("_UseGradient_F", properties);
        MaterialProperty _YPosHigh_F = ShaderGUI.FindProperty("_YPosHigh_F", properties);
        MaterialProperty _YPosLow_F = ShaderGUI.FindProperty("_YPosLow_F", properties);
        MaterialProperty _ColorHigh_F = ShaderGUI.FindProperty("_ColorHigh_F", properties);
        MaterialProperty _ColorLow_F = ShaderGUI.FindProperty("_ColorLow_F", properties);

        MaterialProperty _ColorBack = ShaderGUI.FindProperty("_ColorBack", properties);
        MaterialProperty _UseGradient_B = ShaderGUI.FindProperty("_UseGradient_B", properties);
        MaterialProperty _YPosHigh_B = ShaderGUI.FindProperty("_YPosHigh_B", properties);
        MaterialProperty _YPosLow_B = ShaderGUI.FindProperty("_YPosLow_B", properties);
        MaterialProperty _ColorHigh_B = ShaderGUI.FindProperty("_ColorHigh_B", properties);
        MaterialProperty _ColorLow_B = ShaderGUI.FindProperty("_ColorLow_B", properties);

        MaterialProperty _ColorRight = ShaderGUI.FindProperty("_ColorRight", properties);
        MaterialProperty _UseGradient_R = ShaderGUI.FindProperty("_UseGradient_R", properties);
        MaterialProperty _YPosHigh_R = ShaderGUI.FindProperty("_YPosHigh_R", properties);
        MaterialProperty _YPosLow_R = ShaderGUI.FindProperty("_YPosLow_R", properties);
        MaterialProperty _ColorHigh_R = ShaderGUI.FindProperty("_ColorHigh_R", properties);
        MaterialProperty _ColorLow_R = ShaderGUI.FindProperty("_ColorLow_R", properties);

        MaterialProperty _ColorLeft = ShaderGUI.FindProperty("_ColorLeft", properties);
        MaterialProperty _UseGradient_L = ShaderGUI.FindProperty("_UseGradient_L", properties);
        MaterialProperty _YPosLow_L = ShaderGUI.FindProperty("_YPosLow_L", properties);
        MaterialProperty _YPosHigh_L = ShaderGUI.FindProperty("_YPosHigh_L", properties);
        MaterialProperty _ColorHigh_L = ShaderGUI.FindProperty("_ColorHigh_L", properties);
        MaterialProperty _ColorLow_L = ShaderGUI.FindProperty("_ColorLow_L", properties);

        MaterialProperty _ColorTop = ShaderGUI.FindProperty("_ColorTop", properties);
        MaterialProperty _ColorBottom = ShaderGUI.FindProperty("_ColorBottom", properties);



        materialEditor.ShaderProperty(_MainTexture, _MainTexture.displayName);


        //forward Properties
        EditorGUILayout.Space();
        EditorGUILayout.BeginVertical("Box");
        EditorGUILayout.LabelField("Forward", EditorStyles.boldLabel);
        EditorGUILayout.Space();

        if (_UseGradient_F.floatValue == 0)
        {
            materialEditor.ShaderProperty(_ColorForward, "Color");
        }
        materialEditor.ShaderProperty(_UseGradient_F, "Use Gradient");
        if (_UseGradient_F.floatValue != 0)
        {
            materialEditor.ShaderProperty(_YPosHigh_F, "Height");
            materialEditor.ShaderProperty(_YPosLow_F, "Start Y");
            materialEditor.ShaderProperty(_ColorHigh_F, "Color High");
            materialEditor.ShaderProperty(_ColorLow_F, "Color Low");
        }
        EditorGUILayout.EndVertical();


        //backward Properties
        EditorGUILayout.Space();
        EditorGUILayout.BeginVertical("Box");
        EditorGUILayout.LabelField("Backward", EditorStyles.boldLabel);
        EditorGUILayout.Space();


        if (_UseGradient_B.floatValue == 0)
        {
            materialEditor.ShaderProperty(_ColorBack, "Color");
        }
        materialEditor.ShaderProperty(_UseGradient_B, "Use Gradient");
        if (_UseGradient_B.floatValue != 0)
        {
            materialEditor.ShaderProperty(_YPosHigh_B, "Height");
            materialEditor.ShaderProperty(_YPosLow_B, "Start Y");
            materialEditor.ShaderProperty(_ColorHigh_B, "Color High");
            materialEditor.ShaderProperty(_ColorLow_B, "Color Low");
        }
        EditorGUILayout.EndVertical();

        //right Properties
        EditorGUILayout.Space();
        EditorGUILayout.BeginVertical("Box");
        EditorGUILayout.LabelField("Right", EditorStyles.boldLabel);
        EditorGUILayout.Space();

        
        if (_UseGradient_R.floatValue == 0)
        {
            materialEditor.ShaderProperty(_ColorRight, "Color");
        }
        materialEditor.ShaderProperty(_UseGradient_R, "Use Gradient");
        if (_UseGradient_R.floatValue != 0)
        {
            materialEditor.ShaderProperty(_YPosHigh_R, "Height");
            materialEditor.ShaderProperty(_YPosLow_R, "Start Y");
            materialEditor.ShaderProperty(_ColorHigh_R, "Color High");
            materialEditor.ShaderProperty(_ColorLow_R, "Color Low");
        }
        EditorGUILayout.EndVertical();

        //Left Properties
        EditorGUILayout.Space();
        EditorGUILayout.BeginVertical("Box");
        EditorGUILayout.LabelField("Left", EditorStyles.boldLabel);
        EditorGUILayout.Space();

        if (_UseGradient_L.floatValue == 0)
        {
            materialEditor.ShaderProperty(_ColorLeft, "Color");
        }
        materialEditor.ShaderProperty(_UseGradient_L, "Use Gradient");
        if (_UseGradient_L.floatValue != 0)
        {
            materialEditor.ShaderProperty(_YPosHigh_L, "Height");
            materialEditor.ShaderProperty(_YPosLow_L, "Start Y");
            materialEditor.ShaderProperty(_ColorLow_L, "Color High");
            materialEditor.ShaderProperty(_ColorHigh_L, "Color Low");

        }
        EditorGUILayout.EndVertical();

        //Top Properties
        EditorGUILayout.Space();
        EditorGUILayout.BeginVertical("Box");
        EditorGUILayout.LabelField("Top", EditorStyles.boldLabel);
        EditorGUILayout.Space();
        
        materialEditor.ShaderProperty(_ColorTop, "Color");
        
        EditorGUILayout.EndVertical();

        //Bottom Properties
        EditorGUILayout.Space();
        EditorGUILayout.BeginVertical("Box");
        EditorGUILayout.LabelField("Bottom", EditorStyles.boldLabel);
        EditorGUILayout.Space();
        
        materialEditor.ShaderProperty(_ColorBottom, "Color");
        
        EditorGUILayout.EndVertical();
    }
}
