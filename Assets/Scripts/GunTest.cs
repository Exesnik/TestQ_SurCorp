using UnityEngine;

public class GunTest : MonoBehaviour
{
    public Gun gun;
    public Magazine testMagazine;

    private void Start()
    {
        Debug.Log("Ñ Slide " +
        "I Insert Mag " +
        "E Eject Mag " +
        "F Shoot ");

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            gun.CockSlide();
        }
        if (Input.GetKeyDown(KeyCode.I))
        {
            gun.InsertMagazine();
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            gun.EjectMagazine();
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            gun.Shoot();
        }
    }
}
