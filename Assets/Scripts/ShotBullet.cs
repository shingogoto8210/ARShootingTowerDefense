using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotBullet : MonoBehaviour
{
    [SerializeField]
    private GameObject bulletPrefab;
    [SerializeField]
    private int shotPower;
    //[SerializeField]
    //private ARManager arManager;

    void Update()
    {
        if (Input.GetMouseButtonDown(0)/* && arManager.currentARState == ARState.Play*/)
        {
            GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
            Rigidbody rbBullet = bullet.GetComponent<Rigidbody>();
            rbBullet.AddForce(transform.forward * shotPower);
            Destroy(bullet, 5.0f);
        }
    }
}
