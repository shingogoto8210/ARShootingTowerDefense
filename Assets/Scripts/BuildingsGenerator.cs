using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingsGenerator : MonoBehaviour
{
    [SerializeField]
    private BuildingsController buildings;

    /// <summary>
    /// Œš•¨‚Ì¶¬
    /// </summary>
    public BuildingsController GenerateBuildings()
    {
        buildings = Instantiate(buildings, transform.position, Quaternion.identity);
        Debug.Log("Œš•¨‚Ì¶¬");
        return buildings;
    }
}
