using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public Transform firePoint; // declare a transform value called "Fire Point" found in Unity "Shooting" script component
    public GameObject bulletPrefab;
    public float bulletForce = 10f;
    public float fireRate = 0.02f; //0.2f = 5 bullets per second damn
    private float nextFireTime = 0f;
    public AudioSource shootSound; // declare AudioSource variable
    public Bullet bulletRotates;
    public float rotationSpeed;


    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.Space) && Time.time >= nextFireTime){
            Shoot();
            nextFireTime = Time.time + fireRate; // This sets when we can shoot next
        }
    }

    void Shoot(){
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation); // creates new bullet and clones it with "Instanstiate"
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.right * bulletForce, ForceMode2D.Impulse); // "firePoint.right" makes bullets shoot right (wow)

        if(bulletRotates){
            Bullet bullet1 = bullet.GetComponent<Bullet>();
            bullet1.rotationSpeed = rotationSpeed;
        }

        shootSound.Play();
    }
}
