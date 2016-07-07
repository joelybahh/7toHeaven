using UnityEngine;
using System.Collections;

public class Shotgun : MonoBehaviour {

    public Transform[] gunEnd;
    public int bulletsPerShot;
    public int damageAmount = 10;
    public GameObject hitObj;
    public GameObject hitBloodObj;
    public float floatInFrontOfWall = 0.00001f;

    public float fireRate = 1.5f;
    float shootTimer = 0.0f;
    bool canShoot;

    bool cockBackSound = false;
    bool shellDropSound = false;

    public float reloadTime = 3.5f;
    float reloadTimer = 0.0f;

    int ammo;
    public int clipSize = 10;

    bool doOnce = true;

    void start() {
        ammo = clipSize;
        canShoot = true;
        GameManager.Instance.isReloading = false;
    }

    void Update() {
        if (doOnce) {
            ammo = clipSize;
            doOnce = false;
        }

        if (Input.GetMouseButtonDown(0) && canShoot && !GameManager.Instance.isReloading) {
            RaycastHit hit;
            ammo--;
            AudioManager.instance.PlaySound("Shoot");
            //Debug.DrawRay(gunEnd.position, gunEnd.forward * 10.0f, Color.red, 1000.0f);
            for (int i = 0; i < gunEnd.Length; i++) {
                if (Physics.Raycast(gunEnd[i].position, gunEnd[i].forward * 10.0f, out hit, Mathf.Infinity)) {
                    if (hit.transform.tag == "Enemy") {
                        hit.transform.gameObject.SendMessage("ApplyDamage", damageAmount);
                       
                        GameObject tempBloodMark = Instantiate(hitBloodObj, hit.point, Quaternion.LookRotation(hit.normal)) as GameObject;
                        tempBloodMark.transform.Rotate(Vector3.right * 90);

                        Destroy(tempBloodMark, 0.4f);
                    } else {
                        GameObject tempBullMark = Instantiate(hitObj, hit.point + (hit.normal * floatInFrontOfWall), Quaternion.LookRotation(hit.normal)) as GameObject;
                        tempBullMark.transform.Rotate(Vector3.right * 90);

                        Destroy(tempBullMark, 3.0f);
                    }
                }
            }
            canShoot = false;
        }

        if (!canShoot) {
            shootTimer += Time.deltaTime;
            if (shootTimer >= (fireRate / 3)) {
                if (!cockBackSound) {
                    AudioManager.instance.PlaySound("CockBack");
                    cockBackSound = true;
                }
            }
            if (shootTimer >= (fireRate / 4)) {
                if (!shellDropSound) {
                    AudioManager.instance.PlaySound("ShellDrop");
                    shellDropSound = true;
                }
            }
        }
        if (shootTimer >= fireRate) {
            canShoot = true;
            cockBackSound = false;
            shellDropSound = false;
            shootTimer = 0.0f;
        }

        if (ammo <= 0) {
            GameManager.Instance.isReloading = true;
            reloadTimer += Time.deltaTime;
            if (reloadTimer >= reloadTime) {
                GameManager.Instance.isReloading = false;
                ammo = clipSize;
                reloadTimer = 0.0f;
            }
        }
    }
}