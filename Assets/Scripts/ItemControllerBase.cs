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
    /// Bullet�ɓ���������A�C�e�����ꎞ�����Ȃ����āCItem���\�b�h�𔭓�����
    /// </summary>
    /// <param name="other"></param>
    protected void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Bullet"))
        {
            Destroy(other.gameObject);
            Instantiate(EffectDataBase.instance.itemGetEffect, transform.position, Quaternion.identity);
            //Destroy���Ă��܂�����C���̌�̃��\�b�h���g���Ȃ��̂ŁC�ꎞ���������Č����Ȃ�����
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
