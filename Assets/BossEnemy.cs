using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class BossEnemy : MonoBehaviour
{
    public enum Stage {
      WaitingToStart, Stage1, Stage2, Stage3, Stage4, End
    }
    
    public static event Action<BossEnemy> OnEnemyKilled;
    [SerializeField] float currentHealth, maxHealth = 100f;
    private Stage stage;

    // private static BossShooter bossss;
    [SerializeField] private BossShooter bossAttack, bossAttack4;
    [SerializeField] private BossShooter2 bossAttack2;  
    [SerializeField] private BossShooter3 bossAttack3;

    [SerializeField] AudioSource BossDamageTaken;
    [SerializeField] AudioSource BossDefeated;

    // void Awake()
    // {
    //     // stage = Stage.WaitingToStart;
    // }


    // Start is called before the first frame update
    void Start()
    {
        
        currentHealth = maxHealth; 
        float updateyeah = updateHealthText(currentHealth);
        stage = Stage.WaitingToStart;
        StartNextStage();
    }

    public float updateHealthText(float health){
      return health;
    }
    public void TakeDamage(float damageAmount){
      // ! play boss taking damage sound here!
      BossDamageTaken.Play();
      currentHealth -= damageAmount;

      if(currentHealth <= 0){
        // ! add explosion gif over boss
        Destroy(gameObject);
        OnEnemyKilled?.Invoke(this); // boss literally dies fr
        BossDefeated.Play(); // play explosion sound here!
      }
    }
    public void BossStageTracker(){
      switch(stage){
        case Stage.Stage1:
          // bossAttack.Attack();
          if(currentHealth <= 90){
            //boss under %70
            Debug.Log("Boss health is now under: "+currentHealth);
            StartNextStage();
          }else{
            bossAttack.Attack();
          }
          break;
        case Stage.Stage2:
          
          if(currentHealth <= 70){
            //boss under %50
            Debug.Log("Boss health is now under "+currentHealth);
            StartNextStage();
          }else{
            bossAttack2.Attack();
          }
          break;
        case Stage.Stage3:
          if(currentHealth <= 50){
            //boss under %50
            Debug.Log("Boss health is now under "+currentHealth);
            StartNextStage();
          }else{
            bossAttack3.Attack();
          }
          break;
        case Stage.Stage4:
          if(currentHealth <= 20){
            //boss under %20
            Debug.Log("Boss health is now under "+currentHealth);
            StartNextStage();
          }else{
            bossAttack4.Attack();
          }
          break;
        case Stage.End:
          if(currentHealth <= 0){
            // ! add explosion gif over boss
            Destroy(gameObject);
            OnEnemyKilled?.Invoke(this); // boss literally dies fr
            BossDefeated.Play(); // play explosion sound here!
            }
          break;
  }
}
    
    public void StartNextStage(){ //set boss battle stages
      switch(stage){
        case Stage.WaitingToStart:
          stage = Stage.Stage1;
          break;
        case Stage.Stage1:
          stage = Stage.Stage2;
          break;
        case Stage.Stage2:
          stage = Stage.Stage3;
          break;
        case Stage.Stage3:
          stage = Stage.Stage4;
          break;
        case Stage.Stage4:
        stage = Stage.End;
          break;
        case Stage.End:
          break;
      }
      Debug.Log("Now Current stage: " + stage);
    }

    // Update is called once per frame
    void Update()
    {
        BossStageTracker();
    }
}
