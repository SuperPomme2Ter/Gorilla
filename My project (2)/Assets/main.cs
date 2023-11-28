using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class main : MonoBehaviour
{
    public int gameState;
    public bool transition;
    public ShootTurn proj;
    public Movements mouv;
    public bool bulletTime;
    public IATurn IA;
    

    // Start is called before the first frame update
    void Start()
    {
        gameState = 1;
        transition = false;
        bulletTime = false;

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (proj.projectile.GetComponent<Ball>().transition)
        {
            if (transition)
            {
                gameState = 4;
                proj.projectile.GetComponent<Ball>().transition = false;
                transition = false;
                IA.Recall();
                
            }
            else
            {
                gameState = 1;
                proj.projectile.GetComponent<Ball>().transition = false;
                mouv.grounded = true;
            }
        }
    }
}
