using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingsGenerator : MonoBehaviour
{
    [SerializeField]
    private BuildingsController buildings;

    /// <summary>
    /// �����̐���
    /// </summary>
    public BuildingsController GenerateBuildings()
    {
        buildings = Instantiate(buildings, transform.position, Quaternion.identity);
        Debug.Log("�����̐���");
        return buildings;
    }
}
