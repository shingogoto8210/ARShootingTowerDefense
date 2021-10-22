using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ShotBullet : MonoBehaviour
{
    [SerializeField]
    private GameObject bulletPrefab;
    [SerializeField]
    private int shotPower;
    [SerializeField]
    private GameManager gameManager;
    private bool isShot;
    private int shotInterval;
    private AudioSource audioSource;
    [SerializeField]
    private AudioClip shotSound;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    /// <summary>
    /// 左クリックで弾を発射する
    /// </summary>
    void Update()
    {
        //連続して撃てないようにする
        shotInterval++;
        if(shotInterval > 10)
        {
            isShot = true;
            shotInterval = 0;
        }
        //スキルボタンを押したときは弾を撃たない
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }
        if (Input.GetMouseButtonDown(0) && gameManager.currentGameState == ARState.Play && isShot == true )
        {
            GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
            Rigidbody rbBullet = bullet.GetComponent<Rigidbody>();
            rbBullet.AddForce(transform.forward * shotPower);
            audioSource.PlayOneShot(shotSound);
            Instantiate(EffectDataBase.instance.shotBulletEffect, transform.position, Quaternion.identity);
            Destroy(bullet, 5.0f);
            isShot = false;
        }
    }
}
