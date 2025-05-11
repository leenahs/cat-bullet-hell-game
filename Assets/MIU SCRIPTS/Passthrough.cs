using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Passthrough : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        GameObject PlayerCat = GameObject.Find("PlayerCat"); // Must match the GameObject's name exactly
        Collider2D colA = GetComponent<Collider2D>();
        Collider2D colB = PlayerCat.GetComponent<Collider2D>();
        Physics2D.IgnoreCollision(colA, colB);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
