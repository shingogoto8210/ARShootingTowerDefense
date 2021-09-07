using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotBullet : MonoBehaviour
{
    [SerializeField]
    private GameObject bulletPrefab;
    [SerializeField]
    private int shotPower;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
            Rigidbody rbBullet = bullet.GetComponent<Rigidbody>();
            Debug.Log("‰Á‘¬");
            rbBullet.AddForce(transform.forward * shotPower);
            Debug.Log(rbBullet.velocity);
            Destroy(bullet, 5.0f);
        }
    }
}
