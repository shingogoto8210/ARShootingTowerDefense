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


    private IEnumerator OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Bullet") && itemNo == 0)
        {
            Destroy(other.gameObject);
            gameObject.GetComponent<MeshRenderer>().enabled = false;
            gameObject.GetComponent<Collider>().enabled = false;
            yield return StartCoroutine(StopItem());
            Debug.Log("Destroy");
            Destroy(gameObject);
            
        }
    }

    private IEnumerator StopItem()
    {
        for (int i = 0; i < gameManager.enemiesList.Count; i++)
        {
            gameManager.enemiesList[i].StopEnemy();
        }
        Debug.Log("stop");
        yield return new WaitForSeconds(3.0f);
        for (int i = 0; i < gameManager.enemiesList.Count; i++)
        {
            gameManager.enemiesList[i].ResumeEnemy();
        }
        Debug.Log("start");
    }

    //private void BarrierItem()
    //{
    //  defenseBaseTran = GameObject.Find("DefenseBase").transform;
    //  Instantiate(barrier, defenseBaseTran.position, Quaternion.identity);
    //}
}
