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

    void Update()
    {
        shotInterval++;
        if(shotInterval > 10)
        {
            isShot = true;
            shotInterval = 0;
        }
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }
        if (Input.GetMouseButtonDown(0) && gameManager.currentGameState == ARState.Play && isShot == true)
        {
            GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
            Rigidbody rbBullet = bullet.GetComponent<Rigidbody>();
            rbBullet.AddForce(transform.forward * shotPower);
            Instantiate(EffectDataBase.instance.shotBulletEffect, transform.position, Quaternion.identity);
            Destroy(bullet, 5.0f);
            isShot = false;
        }
    }
}
