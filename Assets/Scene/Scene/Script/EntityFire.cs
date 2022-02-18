using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityFire : MonoBehaviour
{
    [SerializeField] Transform _spawnPoint;
    [SerializeField] Bullet _bulletPrefab;
    [SerializeField] BulletPool bulletPool;

    public bool canFire = true;

    public void FireBullet(int power)
    {
        if (canFire)
        {
            var b = bulletPool.GetBullet(_spawnPoint.position, Quaternion.identity)
                .Init(_spawnPoint.TransformDirection(Vector3.right), power);
        }
    }

}
