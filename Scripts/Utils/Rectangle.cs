using System.Collections.Generic;
using UnityEngine;

namespace Scripts.Utils
{
    public class Rectangle
    {
        private readonly Vector3Int firstCorner;
        private readonly Vector3Int secondCorner;
        private readonly int cellSize;
        
        public float GetAreaXZ =>
            (Mathf.Abs(secondCorner.x - firstCorner.x) / cellSize) *
            (Mathf.Abs(secondCorner.z - firstCorner.z) / cellSize);
        
        public float GetPerimeterXZ =>
            2 * ((Mathf.Abs(secondCorner.x - firstCorner.x) / cellSize) +
            (Mathf.Abs(secondCorner.z - firstCorner.z) / cellSize));

        public Rectangle(Vector3Int firstCorner, Vector3Int secondCorner, int cellSize = 1)
        {
            this.firstCorner = firstCorner;
            this.secondCorner = secondCorner;
            this.cellSize = cellSize;
        }

        public Vector3[] GetSegmentsXZAxis()
        {
            var result = new List<Vector3>();

            List<int> xList = new List<int>();
            for (int i = 0; i <= Mathf.Abs(secondCorner.x - firstCorner.x); i+= cellSize) 
                xList.Add(firstCorner.x + Mathf.Clamp(secondCorner.x - firstCorner.x, -1, 1) * i);

            List<int> zList = new List<int>();
            for (int i = 0; i <= Mathf.Abs(secondCorner.z - firstCorner.z); i+= cellSize) 
                zList.Add(firstCorner.z + Mathf.Clamp(secondCorner.z - firstCorner.z, -1, 1) * i);

            foreach (var x in xList)
            foreach (var z in zList)
                result.Add(new Vector3(x, 0, z));

            return result.ToArray();
        }

    }
}