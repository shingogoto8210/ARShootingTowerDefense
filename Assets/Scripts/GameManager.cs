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
        //建物生成→フィールド上に移動
        yield return StartCoroutine(buildingsGenerator.Generate(buildings));
        //TODO GameStartの文字表示→消える
        //Enemy移動開始
    }

    void Update()
    {
        
    }
}
