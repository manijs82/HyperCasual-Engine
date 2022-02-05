using System;
using HyperCasual_Engine.Attributes;
using HyperCasual_Engine.Attributes.AttributeTypes;
using UnityEditor;

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
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}