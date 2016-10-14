using UnityEngine;
using System.Collections;

public class Gun : MonoBehaviour
{
    public Transform muzzle;
    public Projectile bullet;

    public string weaponName = "New Weapon Name";
    public int cost;
    public string description = "New Weapon";

    public float fireRate;
    public float bulletSpeed;
    public float damage;

    float nextShotTime;

    public void Shoot() {
        
        if (Time.time > nextShotTime) {
            nextShotTime = Time.time + fireRate / 1000;
            Projectile newProjectile = Instantiate(bullet, muzzle.position, muzzle.rotation) as Projectile;
            newProjectile.SetSpeed(bulletSpeed);
            newProjectile.SetDamage(damage);
        }
    }
}
