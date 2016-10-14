using UnityEngine;
using System.Collections;

public class TurretBullet : Projectile {

    Transform target;

	void FixedUpdate() {

        if (target) {
            Vector3 dir = target.transform.position - transform.position;
            transform.LookAt(target, Vector3.up);
            
            //GetComponent<Rigidbody>().velocity = dir.normalized * speed;
        }
        else {
            // if no target don't shoot
            // not sure how this will work yet
            Destroy(gameObject, float.Epsilon);
        }
    }

    public void SetTarget(Transform target) {
        this.target = target;
    }
}
