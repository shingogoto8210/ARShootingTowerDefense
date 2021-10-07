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
    [SerializeField]
    private GameObject effectPrefab;
    private GameObject effect;
    private GameManager gameManager;

    void Start()
    {
        dbHP = maxdbHP;
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.TryGetComponent(out EnemyController enemy))
        {
            dbHP--;
            effect = Instantiate(effectPrefab, new Vector3(transform.position.x, transform.position.y + 0.25f, transform.position.z), Quaternion.identity);
            Destroy(effect, 1.0f);
            enemy.DestoryEnemy();
            if(dbHP <= 0)
            {
                Destroy(gameObject);
                gameManager.currentGameState = ARState.GameUp;
                Debug.Log("Game Over");
            }
        }
        else if (other.gameObject.CompareTag("Enemy"))
        {
            dbHP--;
            effect = Instantiate(effectPrefab, new Vector3(transform.position.x, transform.position.y + 0.25f, transform.position.z), Quaternion.identity);
            Destroy(effect, 1.0f);
        }
    }
}
