using UnityEditor;
using UnityEngine;

namespace HyperCasual_Engine.Editor
{
    public class HceWindow : EditorWindow
    {
        public HceWindowTab[] Tabs;
        
        private readonly string[] _tabsNames = {"Magic Buttons", "Camera"};
        private int _tabIndex;

        [MenuItem("Tools/HCE/Main Window")]
        private static void ShowWindow()
        {
            var window = GetWindow<HceWindow>();
            window.titleContent = new GUIContent("Hce Editor");
            window.Show();
        }

        private void OnEnable()
        {
            InitTabs();
        }

        private void InitTabs()
        {
            Tabs = new HceWindowTab[_tabsNames.Length];
            Tabs[0] = new MagicButtonsTab();
            Tabs[1] = new CameraSetupTab();

            foreach (var tab in Tabs) tab.OnEnable();
        }

        private void OnGUI()
        {
            _tabIndex = GUILayout.Toolbar(_tabIndex, _tabsNames);
            Tabs[_tabIndex].DrawTab();
        }

        private void OnDisable()
        {
            foreach (var tab in Tabs) tab.OnDisable();
        }
    }
}