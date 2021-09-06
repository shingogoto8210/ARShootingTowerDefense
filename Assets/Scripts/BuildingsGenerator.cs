using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingsGenerator : MonoBehaviour
{
    [SerializeField]
    private BuildingsController buildings;

    /// <summary>
    /// 建物の生成
    /// </summary>
    public BuildingsController GenerateBuildings()
    {
        buildings = Instantiate(buildings, transform.position, Quaternion.identity);
        Debug.Log("建物の生成");
        return buildings;
    }
}
