using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class BuildingsController : MonoBehaviour
{

    /// <summary>
    /// �������t�B�[���h��Ɉړ�����
    /// </summary>
    public void MoveBuildings()
    {
        this.transform.DOMoveY(0.0f, 1.5f);
        Debug.Log("�������t�B�[���h��Ɉړ�");
    }

}
