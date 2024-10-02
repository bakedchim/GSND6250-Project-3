using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public PlayerInfo playerInfo;

    float shootCooldown = 0.1f;
    bool isReloading = false;
    bool canShoot = true;

    public GameObject bulletPrefab;

    public Camera fpsCam;

    // Update is called once per frame
    void Update()
    {
        CheckInput();
    }

    public void CheckInput()
    {
        // Shoot when press left mouse button
        if (Input.GetMouseButton(0) && canShoot && !isReloading)
        {
            canShoot = false;
            Shoot();
            Invoke(nameof(CancelShootCooldown), shootCooldown);
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            Reload();
        }
    }

    public void Shoot()
    {
        if (playerInfo.playerCurrentAmmo > 0)
        {
            playerInfo.playerCurrentAmmo--;
            Debug.Log("Shooting... Current Ammo: " + playerInfo.playerCurrentAmmo);
            RaycastHit hit;
            Vector3 hitLocation;
            // Get the location of center of the screen that hit anything
            if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, 50f))
            {
                hitLocation = hit.point;
            } else
            {
                hitLocation = fpsCam.transform.position + fpsCam.transform.forward * 50f;
            }

            GameObject bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);
            // Get the BulletBehavior script from the bullet
            BulletBehavior bulletBehavior = bullet.GetComponent<BulletBehavior>();
            // Set the hit location of the bullet
            bulletBehavior.hitLocation = hitLocation;
        }
        else
        {
            Debug.Log("Out of Ammo!");
        }
    }

    public void CancelShootCooldown()
    {
        canShoot = true;
    }

    public void Reload()
    {
        StartCoroutine(ReloadCoroutine());
    }

    private IEnumerator ReloadCoroutine()
    {
        isReloading = true;
        // Add one ammo every 0.05s
        while (playerInfo.playerCurrentAmmo < playerInfo.playerMaxAmmo)
        {
            playerInfo.playerCurrentAmmo++;
            Debug.Log("Reloading... Current Ammo: " + playerInfo.playerCurrentAmmo);
            yield return new WaitForSeconds(0.05f);
        }
        isReloading = false;
    }
}
