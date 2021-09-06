using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingsGenerator : MonoBehaviour
{

    /// <summary>
    /// åöï®ÇÃê∂ê¨
    /// </summary>
    public IEnumerator Generate(BuildingsController buildings)
    {
        Instantiate(buildings, transform.position, Quaternion.identity);
        Debug.Log("ê∂ê¨");
        yield return null;
    }
}
