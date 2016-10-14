using UnityEngine;
using System.Collections;

public class GunController : MonoBehaviour {

    public Transform weaponHold;
    float nextShotTime;

    public Gun startingGun;
    Gun equippedGun;

    // equips startingGun
    void Start() {
        if (startingGun != null) {
            EquipGun(startingGun);
        }
    }

    // used to equip a gun
    public void EquipGun(Gun gunToEquip){
        // destorys instance of currently equipped gun
        if (equippedGun != null) {
            Destroy(equippedGun.gameObject);
            weaponHold.Rotate(90, 0, 0);
        }
        
        // rotates arm and then equips
        weaponHold.Rotate(-90,0,0);
        equippedGun = (Gun)Instantiate(gunToEquip, weaponHold.position, weaponHold.rotation);
        equippedGun.transform.parent = weaponHold;
    }

    public Gun GetGun() {
        return equippedGun;
    }

    // calls shoot function from the gun
    public void Shoot() {
        //equippedGun.Shoot();

        if (Time.time > nextShotTime) {
            nextShotTime = Time.time + equippedGun.fireRate / 1000;
            Projectile newProjectile = Instantiate(equippedGun.bullet, equippedGun.muzzle.position, equippedGun.muzzle.rotation) as Projectile;
            newProjectile.SetSpeed(equippedGun.bulletSpeed);
            newProjectile.SetDamage(equippedGun.damage);
        }
    }
}
