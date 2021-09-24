using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "StageSO",menuName = "CreateStageSO")]
public class StageDataSO : ScriptableObject
{
    public List<StageData> stageDatasList = new List<StageData>();  
}

