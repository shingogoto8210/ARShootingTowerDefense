using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class ShotLaser : MonoBehaviour
{
    [SerializeField]
    private GameObject laserPrefab;
    private GameObject laser;
    private Tween tween;
    private DefenseBase target;
    [SerializeField]
    public int shotTimer;
    [SerializeField]
    private int shotInterval;
    private float timer = 0;
    private GameManager gameManager;
    [SerializeField]
    private Text txtShotLaserCount;
    [SerializeField]
    private int maxShotTimer;
    private AudioSource audioSource;

    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        target = GameObject.Find("DefenseBase").GetComponent<DefenseBase>();
        int maxShotTimer = Random.Range(5, 10);
        shotTimer = maxShotTimer;
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if(gameManager.currentGameState == ARState.Play && gameManager.isStop == false)
        {
            timer += Time.deltaTime;
            if(timer > 1)
            {
                timer = 0;
                shotTimer--;
                UpdateDisplayShotLaserCount();
                if(shotTimer <= 0)
                {
                    Shot();
                    audioSource.PlayOneShot(AudioDataBase.instance.enemyLaserSound);
                    int maxShotTimer = Random.Range(5, 10);
                    shotTimer = maxShotTimer;
                    //Debug.Log(maxShotTimer);
                }
            }
        }
    }

    private void Shot()
    {
        //target = gameManager.stage.defenseBase;
        //laser = Instantiate(laserPrefab, transform.position,Quaternion.identity);
        laser = Instantiate(laserPrefab, gameObject.transform);
        laser.transform.parent = gameObject.transform;
        tween = laser.transform.DOMove(target.transform.position, 0.5f).SetEase(Ease.Linear).OnComplete(() => DestroyLaser());
    }

    private void DestroyLaser()
    {
        tween.Kill();
        Destroy(laser);
    }
    private void UpdateDisplayShotLaserCount()
    {
        txtShotLaserCount.text = shotTimer.ToString();
    }
}
