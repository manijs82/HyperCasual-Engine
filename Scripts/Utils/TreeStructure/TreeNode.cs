using System.Collections.Generic;
using UnityEngine;

namespace HyperCasual_Engine.Utils.TreeStructure
{
    [System.Serializable]
    public class TreeNode<T>
    {
        public T value;
        public List<TreeNode<T>> children;
        [HideInInspector] public TreeNode<T> parent;
        [HideInInspector] public int rootDistance;

        public bool HasChildren => children.Count > 0;

        public TreeNode(TreeNode<T> parent, T value)
        {
            this.value = value;
            children = new List<TreeNode<T>>();
            this.parent = parent;
            this.rootDistance = parent.rootDistance + 1;
        }

        public void AddChild(T child)
        {
            children.Add(new TreeNode<T>(this, child));
        }
    }
}