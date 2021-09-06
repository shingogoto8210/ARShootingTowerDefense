using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class BuildingsController : MonoBehaviour
{

    /// <summary>
    /// 建物をフィールド上に移動する
    /// </summary>
    public void MoveBuildings()
    {
        this.transform.DOMoveY(0.0f, 1.5f);
        Debug.Log("建物がフィールド上に移動");
    }

}
