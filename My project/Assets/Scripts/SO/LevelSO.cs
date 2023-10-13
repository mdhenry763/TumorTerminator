using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Level SO", menuName = "Level Management/LevelSO")]
public class LevelSO : ScriptableObject
{
    public int numCancerCells;
    public int numLumps;

    public GameObject manualInterface;
}
