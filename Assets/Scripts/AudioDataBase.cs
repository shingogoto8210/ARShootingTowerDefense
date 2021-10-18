using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioDataBase : MonoBehaviour
{
    public static AudioDataBase instance;
    public AudioClip shotSound;
    public AudioClip bgmSound;
    public AudioClip enemyAttackSound;
    public AudioClip enemyDestroySound;
    public AudioClip enemySummonSound;
    public AudioClip enemyLaserSound;
    public AudioClip defenseBaseDestroySound;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

}
