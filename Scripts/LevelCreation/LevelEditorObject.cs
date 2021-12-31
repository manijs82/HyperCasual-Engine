﻿using UnityEngine;

namespace HyperCasual_Engine.LevelCreation
{
    public class LevelEditorObject : MonoBehaviour
    {
        public GameObject prefab;
        [Tooltip("should scale prefab to match grid size?")]
        public bool scalePrefab;
        public int heightLevel;
        [Header("Grid settings")]
        [Range(1,20)]
        public int gridSize = 1;
        [Range(1,20)]
        public int gridCellSize = 1;
    }
}