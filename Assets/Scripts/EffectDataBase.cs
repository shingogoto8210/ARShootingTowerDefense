using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectDataBase : MonoBehaviour
{
    public static EffectDataBase instance;
    public GameObject enemyAttackEffect;
    public GameObject enemyDestroyEffect;
    public GameObject shotBulletEffect;
    public GameObject defenseBaseAttackEffect;
    public GameObject itemGetEffect;
    public GameObject iceEffect;
    public GameObject lightningEffect;
    public GameObject enemySummonEffect;

    void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
