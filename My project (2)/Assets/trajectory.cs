using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trajectory : MonoBehaviour
{
    // Start is called before the first frame update
    public main game;
    public ShootTurn trail;
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
        if (game.gameState == 2)
        {
            transform.position=trail.transform.position;
            for (int i = 0; i < 50; i++)
            {
                transform.position = trail.currentPos;
                if (trail.currentPos.y < -3.0f)
                    break;
                trail.v += (new Vector3(game.wind, 0, 0) + Physics.gravity) * Time.fixedDeltaTime;
                Vector3 nextPos = trail.currentPos + trail.v * Time.fixedDeltaTime;
                trail.currentPos = nextPos;
            }
        }
    }
}
