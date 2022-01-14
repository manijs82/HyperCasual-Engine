using HyperCasual_Engine.Utils.TreeStructure;
using UnityEditor;
using UnityEngine;

namespace HyperCasual_Engine.Editor
{
    [CustomEditor(typeof(UiCreator))]
    public class UiCreatorEditor : UnityEditor.Editor
    {
        private UiCreator _uiCreator;
        private UnityObjectTree<UiComponent> _tree;
        
        private void OnEnable()
        {
            _uiCreator = target as UiCreator;
            _tree = _uiCreator.componentTree;
        }

        public override void OnInspectorGUI()
        {
            if (GUILayout.Button("Create UI")) _uiCreator.CreateUi();
            if (GUILayout.Button("Destroy UI")) _uiCreator.DestroyUi();
            GUILayout.Space(20);
            
            DrawNode(_tree.rootNode);
            foreach (var node in _tree.Collect(_tree.rootNode)) 
                DrawNode(node);
        }

        private void DrawNode(TreeNode<UiComponent> node)
        {
            using (new EditorGUILayout.HorizontalScope())
            {
                GUILayout.Space(node.rootDistance * 15);
                
                EditorGUILayout.LabelField("Node Name :", GUILayout.Width(75));
                node.value.objectName = EditorGUILayout.TextField(node.value.objectName);
                EditorGUILayout.LabelField("Type :", GUILayout.Width(40));
                node.value.type = (UiComponent.UiType) EditorGUILayout.EnumPopup(node.value.type, GUILayout.Width(100));
                if (GUILayout.Button("Add Child")) 
                    node.AddChild(new UiComponent());
            }
        }
    }
}