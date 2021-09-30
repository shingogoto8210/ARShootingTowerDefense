using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemController : MonoBehaviour
{
    public int itemNo;
    private GameManager gameManager;
    //[SerializeField]
    //private GameObject barrier;
    //private Transform defenseBaseTran;

    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Bullet") && itemNo == 0)
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
            StopItem();
        }

        //else if (other.gameObject.CompareTag("Bullet") && itemNo == 1)
        //{
          //  Destroy(other.gameObject);
          //  BarrierItem();
          //  Destroy(gameObject);
        //}
    }

    private void StopItem()
    {
        for (int i = 0; i < gameManager.enemiesList.Count; i++)
        {
            gameManager.enemiesList[i].StopEnemy();
        }
    }

    //private void BarrierItem()
    //{
      //  defenseBaseTran = GameObject.Find("DefenseBase").transform;
      //  Instantiate(barrier, defenseBaseTran.position, Quaternion.identity);
    //}
}
