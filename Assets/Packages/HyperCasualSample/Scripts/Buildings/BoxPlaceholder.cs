using System.Collections.Generic;
using Packages.HyperCasualSample.Scripts.Data;
using Packages.HyperCasualSample.Scripts.Kernel;
using Packages.HyperCasualSample.Scripts.Services;
using UnityEngine;

namespace Packages.HyperCasualSample.Scripts.Buildings
{
    public class BoxPlaceholder : MonoBehaviour
    {
        private int _maxAmount;

        public Vector3 StartVector = new Vector3(-1.5f, 0, 1);
        public int OneLayerAmount = 6;

        private Vector3 ColumnSpacing = new Vector3(0.79f, 0, 0);
        private Vector3 RowSpacing = new Vector3(0, 0, 0.53f);
        private float YDelta = 0.53f;
        
        private int CurrentAmount = 0;
        private bool isFilled => CurrentAmount < _maxAmount;

        private int currentRow;
        private int currentColumn;
        private int currentLayer;
        
        private void Start()
        {
            _maxAmount = ServiceLocator.Instance.Single<ConfigProvider>().Single<LevelConfig>().BoxPlaceholderMaxAmount;

            for (int i = 0; i < 7; i++)
            {
                Debug.Log(GetEndPosition());
            }
        }

        public void DrawSource()
        {
            if (!isFilled)
            {
                
            }
        }

        // private Vector3 GetStartPosition(int index)
        // {
        //     
        // }

        
        private Vector3 GetEndPosition()
        {
            var resultX = StartVector.x + ColumnSpacing.x * currentColumn;
            var resultZ = StartVector.z + RowSpacing.z * currentRow;
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