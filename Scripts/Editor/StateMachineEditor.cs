using UnityEditor;

namespace HyperCasual_Engine.Editor
{
    [CustomEditor(typeof(StateMachine))]
    public class StateMachineEditor : UnityEditor.Editor
    {
        private StateMachine t;
        
        private void OnEnable()
        {
            t = target as StateMachine;
            t.onStateChange.AddListener(Repaint);
        }

        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            if(!EditorApplication.isPlaying) return;

            EditorGUILayout.Space();
            EditorGUILayout.Space();
            
            EditorGUILayout.LabelField($"Current state : {t.CurrentState}");
        }

        private void OnDisable()
        {
            t.onStateChange.RemoveListener(Repaint);
        }
    }
}