using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class main : MonoBehaviour
{
    public int gameState;
    public bool transition;
    // Start is called before the first frame update
    void Start()
    {
        gameState = 1;
        transition = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
    }
}
