using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class main : MonoBehaviour
{
    public int gameState;
    public bool transition;
    public ShootTurn proj;
    public Movements mouv;
    public bool bulletTime;
    public IATurn IA;
    public float wind;
    public ExploSettings _EXPLOSION;
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        gameState = 1;
        transition = false;
        bulletTime = false;
        wind=(Random.value*100)-50;



    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (proj.projectile.GetComponent<Ball>().transition)
        {
            if (transition)
            {
                _EXPLOSION.transform.position=proj.projectile.transform.position;
                _EXPLOSION.gameObject.SetActive(true);
                gameState = 4;
                proj.projectile.GetComponent<Ball>().transition = false;
                transition = false;
                IA.Recall();
                anim.SetTrigger("Explosion");


            }
            else
            {
                _EXPLOSION.transform.position=proj.projectile.transform.position;
                _EXPLOSION.gameObject.SetActive(true);
                gameState = 1;
                proj.projectile.GetComponent<Ball>().transition = false;
                mouv.grounded = true;
                wind = (Random.value * 100) - 50;
            }
        }
        if(bulletTime)
        {
            proj.projectile.GetComponent <Rigidbody2D>().AddForce(new Vector2(wind,0));
        }
    }
}
