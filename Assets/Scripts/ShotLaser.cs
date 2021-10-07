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
    private GameObject target;
    [SerializeField]
    public int shotTimer;
    [SerializeField]
    private int shotInterval;
    private float timer = 0;
    private GameManager gameManager;
    private UIManager uiManager;
    [SerializeField]
    private Text txtShotLaserCount;

    void Start()
    {
        shotTimer = shotInterval;
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        target = GameObject.Find("DefenseBase");
        uiManager = GameObject.Find("UIManager").GetComponent<UIManager>();
    }

    void Update()
    {
        if(gameManager.currentGameState == ARState.Play)
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
                    shotTimer = shotInterval;
                }
            }
        }
    }

    private void Shot()
    {
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
