using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingsGenerator : MonoBehaviour
{

    /// <summary>
    /// �����̐���
    /// </summary>
    public IEnumerator Generate(BuildingsController buildings)
    {
        Instantiate(buildings, transform.position, Quaternion.identity);
        Debug.Log("����");
        yield return null;
    }
}
