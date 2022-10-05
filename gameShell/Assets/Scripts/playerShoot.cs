using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerShoot : MonoBehaviour
{
    public float projectileSpeed = 500f;
    public float shotTime = .25f;
    public Transform shotSpawn;
    public Rigidbody playerShot;

    [SerializeField] private bool canShoot;
    // Start is called before the first frame update
    void Start()
    {
        canShoot = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButton("Fire1") && canShoot)
        {
            StartCoroutine(FireSpeed());
            Rigidbody _shot;
            _shot = Instantiate(playerShot, shotSpawn.position, shotSpawn.rotation) as Rigidbody;
            _shot.AddForce(shotSpawn.up * projectileSpeed);
        }
    }

    IEnumerator FireSpeed()
    {
        canShoot = false;
        yield return new WaitForSeconds(shotTime);
        canShoot = true;
    }
}
