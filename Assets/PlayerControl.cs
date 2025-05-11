using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{    
    public static PlayerControl Instance { get; private set; } // Singleton instance

    public float movSpeed;
    float speedX, speedY;
    Rigidbody2D rb;

    void Awake()
    {
        // Assign the instance when the game starts
        if (Instance == null){
            Instance = this;
        }
        else
        {
            Debug.LogWarning("More than one PlayerControl in scene!");
            Destroy(gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();    
    }

    // Update is called once per frame
    void Update()
    {
        speedX = Input.GetAxis("Horizontal") * movSpeed;
        speedY = Input.GetAxis("Vertical") * movSpeed;
        rb.velocity = new Vector2(speedX, speedY);
    }
}
