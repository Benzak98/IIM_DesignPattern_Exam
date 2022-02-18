using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

public class BulletPool : MonoBehaviour
{
    [SerializeField] List<Bullet> bulletsOnGame = new List<Bullet>();
    [SerializeField] List<Bullet> bulletsWaitingRoom = new List<Bullet>();
    [SerializeField] AudioClip bulletImpactSFX;
    [SerializeField] ParticleSystem bulletImpactVFX;
    public AudioSource source;

    [SerializeField] Bullet bulletPrefab;
    int nbrBullet = 10;

    public event UnityAction<Vector3> ReceiveEvent;

    private void Awake()
    {
        for (int i = 0; i < nbrBullet; i++)
        {
            Bullet bullet = Instantiate(bulletPrefab);
            bulletsWaitingRoom.Add(bullet);
            bullet.bulletPool = this;
        }
        ReceiveEvent += PlayFX;
    }

    public Bullet GetBullet(Vector3 pos, Quaternion rot)
    {
        Bullet bullet;

        if (bulletsWaitingRoom.Count > 0)
        {
            bullet = bulletsWaitingRoom[0];
            bullet.transform.position = pos;
            bullet.transform.rotation = rot;
            bulletsWaitingRoom.Remove(bullet);
            bullet.gameObject.SetActive(true);
        }
        else
        {
            bullet = Instantiate(bulletPrefab, pos, rot);
            bullet.bulletPool = this;
        }

        bulletsOnGame.Add(bullet);
        return bullet;
    }

    public void ReceiveBullet(Bullet bullet)
    {
        bulletsOnGame.Remove(bullet);
        bulletsWaitingRoom.Add(bullet);
        bullet.gameObject.SetActive(false);
        ReceiveEvent?.Invoke(bullet.transform.position);
    }

    public void PlayFX(Vector3 fxPos)
    {
        source.PlayOneShot(bulletImpactSFX);
        ParticleSystem fx = Instantiate(bulletImpactVFX, fxPos, Quaternion.identity);
        Destroy(fx.gameObject, 0.5f);
    }
}
