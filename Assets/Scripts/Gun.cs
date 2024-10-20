using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public Transform bulletSpawnPoint;
    public GameObject bulletPrefab;
    public float bulletSpeed = 10f;
    public float cooldown;
    [SerializeField] private Vector2 bulletDirection;
    [SerializeField] private Quaternion bulletRotation;
    [SerializeField] private AudioSource shotSound;

    private bool canShoot = true;

    void Update()
    {
        if (canShoot)
        {
            shotSound.Play();
            var bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletRotation);
            bullet.GetComponent<Rigidbody2D>().velocity = bulletDirection * bulletSpeed;
            canShoot = false;
            StartCoroutine(Shoot());
        }
    }
    IEnumerator Shoot()
    {
        yield return new WaitForSeconds(cooldown);
        canShoot = true;
    }
}
