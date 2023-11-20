using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform shootPosition;

    private bool hasShooted;
    private Vector2 shootDirection;

    void Update()
    {
        CheckInputs();
    }

    void CheckInputs()
    {
        float shoot = Input.GetAxisRaw("Fire1");

        if (shoot == 1)
        {
            if (!hasShooted)
            {
                hasShooted = true;

                ShootBullet();
            }
        } else if (shoot == 0)
        {
            hasShooted = false;
        }
    }

    void ShootBullet()
    {
        //TODO change bullet rotation
        GameObject bullet = Instantiate(bulletPrefab, shootPosition.position, Quaternion.identity);
        bullet.GetComponent<BulletFly>().SetDirection(shootDirection);
    }

    public void SetDirection(Vector2 direction)
    {
        shootDirection = direction;
    }
}
