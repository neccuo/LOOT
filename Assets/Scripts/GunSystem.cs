using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunSystem : MonoBehaviour
{
    // gun stats
    public int damage;
    public float timeBetweenShooting, spread, range, reloadTime, timeBetweenShots;
    public int magazineSize, bulletsPerTap, bulletsLeft;
    public bool isAuto;
    int bulletsShot;

    // bools
    bool isShooting, isReadyToShoot, isReloading;
    bool isPlayer;

    // reference
    public GameObject holder;
    public Camera fpsCam;
    public Transform attackPoint;
    public RaycastHit rayHit;
    public LayerMask whatIsEnemy;
    public GameObject flashEffect;

    EventManager eventManager;

    private Ray ray;

    private void Awake() 
    {
        isPlayer = holder.CompareTag("Player");

        eventManager = GameObject.Find("EventManager").GetComponent<EventManager>();

        flashEffect.transform.localScale = new Vector3(0.12f, 0.12f, 0.12f);
        ResetShot();
        ReloadFinished();
    }

    private void Update() 
    {
        Vector3 direction = fpsCam.transform.forward;
        ray = new Ray(fpsCam.transform.position, direction);
        Debug.DrawLine(ray.origin, ray.origin + direction * range, Color.green);

        
        if(isShooting && isReadyToShoot && 0 < bulletsLeft)
        {
            if(!isAuto)
                isShooting = false;
            Shoot();
        }
    }

    public void ShootCommand(bool isActive)
    {
        isShooting = isActive;
    }

    private void Shoot()
    {
        isReadyToShoot = false;
        Instantiate(flashEffect, attackPoint.position, Quaternion.identity);
        if(Physics.Raycast(ray, out rayHit, range, whatIsEnemy))
        {
            Debug.Log(rayHit.collider.name + " is hit.");
            if(isPlayer && rayHit.collider.CompareTag("Enemy"))
            {
                eventManager.PlayerShotLandedEvent.Invoke();
            }
        }
        bulletsLeft--;
        Invoke("ResetShot", timeBetweenShooting);
    }

    private void ActivateHitMark()
    {
        holder.GetComponent<PlayerUI>().HitMarkActive(true);
    }

    private void DeactivateHitMark()
    {
        holder.GetComponent<PlayerUI>().HitMarkActive(false);
    }

    private void ResetShot()
    {
        isReadyToShoot = true;
    }

    public void ReloadCommand()
    {
        if(bulletsLeft < magazineSize && !isReloading)
            Reload();
    }

    private void Reload()
    {
        isReloading = true;
        Invoke("ReloadFinished", reloadTime);
    }

    private void ReloadFinished()
    {
        bulletsLeft = magazineSize;
        isReloading = false;
    }

}
