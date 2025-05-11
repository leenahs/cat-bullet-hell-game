using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BossHealthBar : MonoBehaviour
{
    public Image healthFill;  //health bar image in the herarichy
    public TMP_Text healthText;        // text ui 
    public float fullHealth = 100f;
    
    public BossEnemy bossHealth;
    float currentHealth;

    void Start(){
      currentHealth = fullHealth;
      healthFill.fillAmount = 1f;
      healthText.text = "Bogos Binted - %???";
    }

    // public void TakeDamage(float damageAmount){
    //   currentHealth -= damageAmount;

    //   if(currentHealth <= 0){
    //     Destroy(gameObject);
    //   }
    // }

    // void Update()
    // {
        
    // }
}
