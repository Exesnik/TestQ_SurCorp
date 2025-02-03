using UnityEngine;

public class Gun : MonoBehaviour
{
    [Header("Gun References")]
    public Magazine currentMagazine;
    public Slide gunSlide;
    public Transform magSlot;
    public Transform muzzleHole;

    [Header("Gun Visual")]
    public ParticleSystem muzzleFlash;
    public AudioSource gunshotSound;

    public int currentAmmo;
    public bool isReadyToShoot;

    public void Shoot()
    {
        if (!isReadyToShoot)
        {
            Debug.Log("Cannot shoot: Gun is not cocked.");
            return;
        }
        if (currentAmmo <= 0)
        {
            Debug.Log("Cannot shoot: No ammo.");
            return;
        }

        Debug.Log("Bang!");
        currentAmmo--;
        if (currentMagazine != null)
            currentMagazine.currentAmmoCount = currentAmmo;
        muzzleFlash?.Play();
        gunshotSound?.Play();

        if (Physics.Raycast(muzzleHole.position, muzzleHole.forward, out RaycastHit hit))
            Debug.Log("Hit: " + hit.collider.name);
    }

    public void InsertMagazine()
    {
        Magazine magazine = GetComponentInChildren<Magazine>();

        if (magazine == null)
        {
            Debug.Log("No magazine provided.");
            return;
        }
        if (currentMagazine != null)
        {
            Debug.Log("Magazine already inserted.");
            return;
        }
        Debug.Log("Inserting magazine...");
        currentMagazine = magazine;
        magazine.AttachToGun(this);
        currentAmmo = magazine.currentAmmoCount;
    }

    public void EjectMagazine()
    {
        if (currentMagazine == null)
        {
            Debug.Log("No magazine to eject.");
            return;
        }
        Debug.Log("Ejecting magazine...");
        currentMagazine.DetachFromGun();
        currentMagazine = null;
        currentAmmo = 0;
    }

    public void CockSlide()
    {
        Debug.Log("Cocking slide.");
        isReadyToShoot = true;
        if (gunSlide != null)
            gunSlide.Pull(); 
    }
}
