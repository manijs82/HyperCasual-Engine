using UnityEngine;

namespace HyperCasual_Engine.Editor
{
    public class MagicButtonsTab : HceWindowTab
    {
        public override void DrawTab()
        {
            if (GUILayout.Button("SetUp Scene"))
            {
                MagicButtons.SetUpScene();
            }
        }

        public override void Init() { }
    }
}