using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject hitEffect; // though we didn't provide a hit effect sprite yet.
    public bool bulletRotates = false;
    public float rotationSpeed = 360f;

    
// Recently added "Start()" void method
    void Start(){
        Destroy(gameObject, 5f); // Bullet disappears after 3 seconds no matter what
    }    
    
    void OnCollisionEnter2D(Collision2D collision){
        if (hitEffect != null){
            GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity); // "Quaternion.identity" basically means "no rotation please".
            Destroy(effect, 5f); // destroy the effect after 2 seconds
        }

        if(collision.gameObject.TryGetComponent<BossEnemy>(out BossEnemy enemyComponent)){
            enemyComponent.TakeDamage(1); //damages 1 point
        }
        Destroy(gameObject); // Destroy bullet on collision

        
    }

    void Update(){
        if (bulletRotates){
            transform.Rotate(0, 0, rotationSpeed * Time.deltaTime);  
        }
    }
}
