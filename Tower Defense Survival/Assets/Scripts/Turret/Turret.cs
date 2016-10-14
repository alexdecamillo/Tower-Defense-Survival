using UnityEngine;
using System.Collections;

public abstract class Turret : MonoBehaviour {

    protected Transform target;

    public Transform body;
    public Transform muzzle;
    public TurretBullet projectile;
    public float msBetweenShots;
    public float muzzleVelocity;

    float nextShotTime;

    bool hasTarget;

    protected virtual void Update() {
        Aim();
        if (target) {
        Debug.Log("Being called ruhuhhhhhh");   
            if (Time.time > nextShotTime) {
                nextShotTime = Time.time + msBetweenShots / 1000;
                Shoot();
            }
        }
    }

    void Aim() {
        body.LookAt(target, Vector3.up);
    }

    public void Shoot() {
        TurretBullet newProjectile = Instantiate(projectile, muzzle.position, muzzle.rotation) as TurretBullet;
        newProjectile.SetSpeed(muzzleVelocity);
        newProjectile.SetTarget(target);
    }

    // INSTRUCTIONS FOR AQUIRING TARGET DIFFERENT FOR DIFFERENT TURRETS
    // set instuctions in scripts inheriting from this class
    public abstract void GetTarget();
}