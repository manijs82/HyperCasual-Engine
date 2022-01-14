using System.Collections.Generic;

namespace HyperCasual_Engine.Utils.TreeStructure
{
    [System.Serializable]
    public class UnityObjectTree<T>
    {
        public TreeNode<T> rootNode;
        
        public IEnumerable<TreeNode<T>> Collect(TreeNode<T> root)
        {
            foreach(TreeNode<T> node in root.children)
            {
                if (node == null) continue;
                yield return node;

                if (!node.HasChildren) continue;
                foreach (var child in Collect(node))
                    yield return child;
            }
        }
    }
}