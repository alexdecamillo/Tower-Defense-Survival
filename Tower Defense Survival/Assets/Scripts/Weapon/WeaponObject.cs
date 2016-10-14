using UnityEngine;
using System.Collections;

[System.Serializable]
public class WeaponObject : ScriptableObject
{
    public GameObject weaponModel;
    public Transform muzzle;
    public Projectile bullet;

    public string weaponName = "New Weapon Name";
    public int cost = 10;
    public string description = "New Weapon";

    public float fireRate;
    public float bulletSpeed;
    public float damage;
}
