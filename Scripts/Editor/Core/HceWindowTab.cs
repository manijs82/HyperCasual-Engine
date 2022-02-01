using UnityEditor;

namespace HyperCasual_Engine.Editor
{
    public abstract class HceWindowTab
    {
        public abstract void DrawTab();
        
        public virtual void OnEnable() { }
        
        public virtual void OnDisable()  { }
    }
}