using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingsGenerator : MonoBehaviour
{

    /// <summary>
    /// 建物の生成
    /// </summary>
    public IEnumerator Generate(BuildingsController buildings)
    {
        Instantiate(buildings, transform.position, Quaternion.identity);
        Debug.Log("生成");
        yield return null;
    }
}
