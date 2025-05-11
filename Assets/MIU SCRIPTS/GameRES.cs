using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameRES : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Screen.fullScreenMode = FullScreenMode.Windowed;
        Screen.SetResolution(1280, 720, false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
