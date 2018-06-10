using UnityEngine;
using System.Collections;

public class Done_TriWeaponController : MonoBehaviour
{
    public GameObject shot;
    public Transform shotSpawn;
    public float fireRate;
    public float delay;

    void Start()
    {
        InvokeRepeating("Fire", delay, fireRate);
    }

    void Fire()
    {
        Vector3 newshot = new Vector3(shotSpawn.position.x, shotSpawn.position.y, shotSpawn.position.z);
        
        Instantiate(shot, newshot, shotSpawn.rotation);
        newshot.x--;
        shotSpawn.Rotate(0, -30, 0);
        Instantiate(shot, newshot, shotSpawn.rotation);
        newshot.x += 2;
        shotSpawn.Rotate(0, 60, 0);
        Instantiate(shot, newshot, shotSpawn.rotation);
        shotSpawn.Rotate(0, -30, 0);
        GetComponent<AudioSource>().Play();
    }
}
