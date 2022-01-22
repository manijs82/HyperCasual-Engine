using UnityEditor;
using UnityEngine;

namespace HyperCasual_Engine.Editor
{
    [CustomEditor(typeof(UiPanel))]
    public class UiPanelEditor : UnityEditor.Editor
    {
        private SerializedProperty propOpeningAndClosingMethod;
        private SerializedProperty propOpeningAndClosingStyle;
        private SerializedProperty propInputManager;
        private SerializedProperty propUiButton;
        private SerializedProperty propOnPanelOpen;
        private SerializedProperty propOnPanelClose;
        
        private void OnEnable()
        {
            propOpeningAndClosingMethod = serializedObject.FindProperty("openingAndClosingMethod");
            propOpeningAndClosingStyle = serializedObject.FindProperty("openingAndClosingStyle");
            propInputManager = serializedObject.FindProperty("inputManager");
            propUiButton = serializedObject.FindProperty("uiButton");
            propOnPanelOpen = serializedObject.FindProperty("onPanelOpen");
            propOnPanelClose = serializedObject.FindProperty("onPanelClose");
        }

        public override void OnInspectorGUI()
        {
            serializedObject.Update();
            
            EditorGUILayout.HelpBox("For This Panel's activation and deactivation to work you must have the root image of your panel a child of this object",
                MessageType.Info);
            
            EditorGUILayout.PropertyField(propOpeningAndClosingMethod);
            EditorGUILayout.PropertyField(propOpeningAndClosingStyle);
            
            EditorGUILayout.Space();
            if (propOpeningAndClosingMethod.enumValueIndex == (int)UiPanel.Method.ButtonPress)
                EditorGUILayout.PropertyField(propInputManager);
            if (propOpeningAndClosingMethod.enumValueIndex == (int)UiPanel.Method.UiButton)
                EditorGUILayout.PropertyField(propUiButton);
            
            if(propOpeningAndClosingStyle.enumValueIndex == (int)UiPanel.Style.Animation)
            {
                var tar = (UiPanel) target;
                if (tar.gameObject.GetComponent<Animator>() == null)
                    EditorGUILayout.HelpBox("Attach an Animator to this object", MessageType.Warning);
            }
            
            EditorGUILayout.Space();
            EditorGUILayout.PropertyField(propOnPanelOpen);
            EditorGUILayout.PropertyField(propOnPanelClose);
            
            serializedObject.ApplyModifiedProperties();
        }
    }
}