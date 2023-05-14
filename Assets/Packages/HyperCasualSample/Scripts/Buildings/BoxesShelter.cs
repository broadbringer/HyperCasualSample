using System;
using UnityEngine;

namespace Packages.HyperCasualSample.Scripts.Buildings
{
    public class BoxesShelter : MonoBehaviour
    {
        public int Amount;
        public GameObject BoxPrefab;
        
        public Vector3 StartVector = new Vector3(0, 0, 0);
        public int OneLayerAmount = 6;

        private Vector3 ColumnSpacing = new Vector3(0.79f, 0, 0);
        private Vector3 RowSpacing = new Vector3(0, 0, 0.53f);
        private float YDelta = 0.53f;
        
        private int CurrentAmount = 0;

        private int currentRow;
        private int currentColumn;
        private int currentLayer;

        private void Start()
        {
            for (int i = 0; i < Amount; i++)
            {
                var box = Instantiate(BoxPrefab, transform, false);
                box.transform.localPosition = GetEndPosition();
                box.transform.localScale = new Vector3(1, 1, 1);
            }
        }
        
        public Vector3 GetEndPosition()
        {
            var resultX = StartVector.x + ColumnSpacing.x * currentColumn;
            var resultZ = StartVector.z - RowSpacing.z * currentRow;
            var resultY = YDelta * currentLayer;
            
            IncreaseRow();
            HandleRowFilled();
            HandleColumnFilled();

            return new Vector3(resultX, resultY, resultZ);
        }

        private void IncreaseRow() => 
            currentRow++;

        private void HandleColumnFilled()
        {
            if (currentColumn < 3) return;
            
            currentColumn = 0;
            currentLayer += 1;
        }

        private void HandleRowFilled()
        {
            if (currentRow < 2) return;
            
            currentRow = 0;
            currentColumn++;
        }
    }
}