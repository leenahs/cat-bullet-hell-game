using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 22f;
    [SerializeField] private GameObject particleOnHitPrefabVFX; //not being used yet...
    [SerializeField] private float projectileRange = 10f;
    [SerializeField] private bool isEnemyProjectile = false;

    public bool bulletRotates = false;
    public float rotationSpeed = 360f;

    private Vector3 startPosition;

    private void Start()
    {
        startPosition = transform.position; // ? what is it for?
    }

    // Update is called once per frame
    void Update()
    {
        MoveProjectile();
        DetectFireDistance();
        // transform.Translate(Vector2.right * moveSpeed * Time.deltaTime); // ? wouldn't shoot in right direction only??
    }
    public bool GetIsEnemyProjectile(){
        return isEnemyProjectile;
    }

    public void UpdateProjectileRange(float projectileRange){
        this.projectileRange = projectileRange;
    }

    public void UpdateMoveSpeed(float moveSpeed){
        this.moveSpeed = moveSpeed;
    }

    // private void OnTriggerEnter2D(Collider2D other ) // OnTriggerEnter2D(Collider2D collision)
    // {
    //     //declare EnemyHealth, Indestructible, PlayerHealth variables
    // }

    private void DetectFireDistance(){
        if(Vector3.Distance(transform.position, startPosition) > projectileRange){
            Destroy(gameObject);
        }
    }

    private void MoveProjectile(){
        transform.Translate(Vector3.right * Time.deltaTime * moveSpeed);
        
        // if(bulletRotates){
        //     // Bullet bullet1 = bullet.GetComponent<Bullet>();
        //     // bullet1.rotationSpeed = rotationSpeed;
        //     transform.Rotate(0, 0, rotationSpeed * Time.deltaTime);  
        // }
    }
}
