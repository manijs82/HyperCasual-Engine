using HyperCasual_Engine.Utils.TreeStructure;
using UnityEngine;

namespace HyperCasual_Engine
{
    public class UiCreator : MonoBehaviour
    {
        public UnityObjectTree<UiComponent> componentTree;

        public void CreateUi()
        {
            componentTree.rootNode.value.CreateComponent(transform, null, true);
            foreach (var node in componentTree.Collect(componentTree.rootNode))
            {
                node.value.CreateComponent(transform, node.parent.value);
            }
        }

        public void DestroyUi()
        {
            
        }
    }
}