using UnityEditor;
using UnityEngine;

namespace HyperCasual_Engine.Editor
{
    public class HceWindow : EditorWindow
    {
        private readonly string[] _tabsNames = {"Magic Buttons", "Camera", "Level"};
        private int _tabIndex;
        private HceWindowTab[] _tabs;

        [MenuItem("HCE/Window")]
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
            _tabs = new HceWindowTab[_tabsNames.Length];
            _tabs[0] = new MagicButtonsTab();
            _tabs[1] = new CameraSetupTab();
            _tabs[2] = new LevelCreatorTab();

            foreach (var tab in _tabs)
            {
                tab.Init();
            }
        }

        private void OnGUI()
        {
            _tabIndex = GUILayout.Toolbar(_tabIndex, _tabsNames);
            _tabs[_tabIndex].DrawTab();
        }
    }
}