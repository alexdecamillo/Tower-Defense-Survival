using UnityEngine;
using System.Collections;

public class RocketTurret : Turret {

    protected override void Update() {
        GetTarget();
        base.Update();
    }

    // GETS TARGET FOR SPECIFIC TURRET
    public override void GetTarget() {

        Enemy[] Enemies = FindObjectsOfType<Sprinter>();

        if (Enemies.Length != 0) {
            Enemy closestEnemy = Enemies[0];
            for (int i = 1; i < FindObjectsOfType<Sprinter>().Length; i++) {
                if (Vector3.Distance(transform.position, Enemies[i].transform.position) <=
                        Vector3.Distance(transform.position, closestEnemy.transform.position)) {

                    closestEnemy = Enemies[i];
                }
            }
            target = closestEnemy.GetComponentInChildren<Transform>();
        }
    }

}
