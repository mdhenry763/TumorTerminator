using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    [Header("Scene References: ")]
    [SerializeField] private GameObject[] cancerCells;

    public int GetNumCancerCells()
    {
        return cancerCells.Length;
    }

    public void SetCancerCellsActive()
    {
        foreach(var cell in cancerCells)
        {
            cell.SetActive(true);
        }
    }
    
}
