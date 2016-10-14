using UnityEngine;
using System.Collections;

[RequireComponent (typeof(PlayerController))]
[RequireComponent (typeof(GunController))]
public class Player : LivingEntity {
    
    public float moveSpeed = 5f;
    public bool menu = false;
    public bool paused = false;
    public bool alive = true;

    int points = 0;

    PlayerController controller;
    Camera viewCamera;
    GunController gunController;

    Core core;

    public event System.Action OnPause;
    public event System.Action PointChange;

    protected override void Start () {
        
        base.Start();
        controller = GetComponent<PlayerController>();
        gunController = GetComponent<GunController>();
        core = FindObjectOfType<Core>();
        viewCamera = Camera.main;
        OnDeath += SetDead;
        //subscribe to core death so player dies if core dies
        core.OnDeath += Die;
        
    }

	protected void Update () {

        if (!paused) {
            if (!menu) {
                // Movement input
                Vector3 moveInput = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
                Vector3 moveVeloctiy = moveInput.normalized * moveSpeed;
                controller.Move(moveVeloctiy);

                // Weapon input
                if (Input.GetMouseButton(0)) {
                    gunController.Shoot();
                }
            }

            // Look input
            Ray ray = viewCamera.ScreenPointToRay(Input.mousePosition);
            Plane groundPlane = new Plane(Vector3.up, Vector3.zero);
            float rayDistance;

            if (groundPlane.Raycast(ray, out rayDistance)) {
                Vector3 point = ray.GetPoint(rayDistance);
                //Debug.DrawLine(ray.origin, point, Color.red);
                controller.LookAt(point);
            } 
        }
        
        // pause controller
        if (Input.GetKeyDown(KeyCode.Escape)) {
            if (OnPause != null) {
                Debug.Log("pause");
                Pause();
            }
        }

        if (Input.GetKeyDown(KeyCode.R)) {
            if (OnPause != null) {
                Debug.Log("pause");
                Pause();
            }
            FindObjectOfType<PauseMenu>().Store();
        }
    }

    public void Pause() {
        paused = !paused;
        OnPause();
    }

    void SetDead() {
        alive = false;
    }

    public void AddPoints(int points) {
        this.points += points;
        PointChange();
    }

    public void RemovePoints(int points) {
        this.points -= points;
        PointChange();
    }

    public int GetPoints() {
        return points;
    }

}
