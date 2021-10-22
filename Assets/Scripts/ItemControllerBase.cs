using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemControllerBase : MonoBehaviour
{
    public int itemNo;
    protected GameManager gameManager;
    protected void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    /// <summary>
    /// Bulletに当たったらアイテムを一時見えなくして，Itemメソッドを発動する
    /// </summary>
    /// <param name="other"></param>
    protected void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Bullet"))
        {
            Destroy(other.gameObject);
            Instantiate(EffectDataBase.instance.itemGetEffect, transform.position, Quaternion.identity);
            //Destroyしてしまったら，その後のメソッドが使えないので，一時小さくして見えなくする
            gameObject.transform.localScale = new Vector3(0, 0, 0);
            gameObject.GetComponent<Collider>().enabled = false;
            Item();
            Destroy(gameObject);
        }
    }

    protected virtual void Item()
    {
    }
}
