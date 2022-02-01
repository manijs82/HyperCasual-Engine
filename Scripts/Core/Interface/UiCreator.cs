using HyperCasual_Engine.Utils.TreeStructure;
using UnityEngine;

namespace HyperCasual_Engine
{
    public class UiCreator : MonoBehaviour
    {
        public UnityObjectTree<UiComponent> componentTree;

        public void CreateUi()
        {
            DestroyUi();
            componentTree.rootNode.value.CreateComponent(transform, componentTree.rootNode.value);
            foreach (var node in componentTree.Collect(componentTree.rootNode))
            {
                var parent = GameObject.Find(node.parent.value.objectName);
                node.value.CreateComponent(parent.transform, node.parent.value);
            }
        }

        public void DestroyUi()
        {
            if(transform.childCount == 0) return;
            for (int i = transform.childCount - 1; i >= 0; i--) 
                DestroyImmediate(transform.GetChild(i).gameObject);
        }
    }
}