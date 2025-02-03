using UnityEngine;

public class Magazine : MonoBehaviour
{
    public int maxAmmoCount = 12;
    public int currentAmmoCount;
    public bool onGun = false;
    public Gun attachedGun;

    public void AttachToGun(Gun gun)
    {
        attachedGun = gun;
        onGun = true;
        Debug.Log("Magazine attached to gun.");
    }

    public void DetachFromGun()
    {
        attachedGun = null;
        onGun = false;
        Debug.Log("Magazine detached from gun.");

        // Destroy(this.gameObject);

    }
}
