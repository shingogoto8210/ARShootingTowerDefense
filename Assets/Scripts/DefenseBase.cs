using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class DefenseBase : MonoBehaviour
{
    public int dbHP;
    [SerializeField]
    private int maxdbHP;
    void Start()
    {
        dbHP = maxdbHP;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.TryGetComponent(out EnemyController enemy))
        {
            dbHP--;
            Destroy(enemy.gameObject);
            enemy.tween.Kill();
            if(dbHP <= 0)
            {
                Destroy(gameObject);
                Debug.Log("Game Over");
                SceneManager.LoadScene("GameOver");
            }
        }
    }
}
