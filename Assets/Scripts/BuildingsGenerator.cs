using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingsGenerator : MonoBehaviour
{
    [SerializeField]
    private BuildingsController buildings;

    /// <summary>
    /// Œš•¨‚Ì¶¬‚ÆˆÚ“®
    /// </summary>
    public void Start()
    {
        buildings = Instantiate(buildings, transform.position, Quaternion.identity);
        buildings.MoveBuildings();
    }
}
