using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private BuildingsGenerator buildingsGenerator;
    [SerializeField]
    private BuildingsController buildings;
    IEnumerator Start()
    {
        //�����������t�B�[���h��Ɉړ�
        yield return StartCoroutine(buildingsGenerator.Generate(buildings));
        //TODO GameStart�̕����\����������
        //Enemy�ړ��J�n
    }

    void Update()
    {
        
    }
}
