using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class Weapon : MonoBehaviour
{
    public string weaponName = "奶油手";
    public float shootCoolDown = 0.5f;
    bool canShoot = true;
    void Start()
    {
        PlayerManager.Instance.player.weapon = this;
    }

    public virtual void Shoot()
    {
        if (canShoot)
        {
            SpawnBullet();
            Debug.Log("吃我的" + weaponName + "！！！");
            StartCoroutine(ShootCoolDown());
        }
    }

    public virtual void SpawnBullet()
    {

    }

    public virtual IEnumerator ShootCoolDown()
    {
        canShoot = false;
        yield return new WaitForSeconds(shootCoolDown);
        canShoot = true;
    }
}
