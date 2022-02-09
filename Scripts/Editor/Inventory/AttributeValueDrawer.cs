using System;
using HyperCasual_Engine.Attributes;
using HyperCasual_Engine.Attributes.AttributeTypes;
using UnityEditor;
using UnityEngine;

namespace HyperCasual_Engine.Editor
{
    public static class AttributeValueDrawer
    {
        public static void Draw(AttributeBase attribute)
        {
            switch (attribute)
            {
                case IntAttribute _:
                    attribute.SetValue(EditorGUILayout.IntField("Int Value", (int)attribute.GetValue()));
                    break;
                case TextAttribute _:
                    attribute.SetValue(EditorGUILayout.TextField("Text Value", (string)attribute.GetValue()));
                    break;
                case BoolAttribute _:
                    attribute.SetValue(EditorGUILayout.Toggle("Bool Value", (bool)attribute.GetValue()));
                    break;
                case MultiLineTextAttribute _:
                    using (new EditorGUILayout.HorizontalScope())
                    {
                        EditorGUILayout.LabelField("Text Value", GUILayout.Width(70));
                        attribute.SetValue(EditorGUILayout.TextArea((string)attribute.GetValue(), GUILayout.MaxHeight(75)));
                    }
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}