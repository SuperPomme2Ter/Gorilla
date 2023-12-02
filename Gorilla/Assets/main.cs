using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine.SceneManagement;
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
    public GameObject EXPLOSION;
    public GameObject Joueur;
    public GameObject Bot;
    public Sprite ded;
    public AudioSource Bong;
    private float temps = 0;
    // Start is called before the first frame update
    void Start()
    {
        gameState = 1;
        transition = false;
        bulletTime = false;
        wind=(Random.value*10)-5;



    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (gameState <11)
        {
            if (proj.projectile.GetComponent<Ball>().transition)
            {
                if (transition)
                {

                    gameState = 4;
                    proj.projectile.GetComponent<Ball>().transition = false;
                    transition = false;
                    IA.Recall();
                    EXPLOSION.transform.position = proj.projectile.transform.position;
                    EXPLOSION.GetComponent<Animator>().SetTrigger("Explosion");


                }
                else
                {
                    gameState = 1;
                    proj.projectile.GetComponent<Ball>().transition = false;
                    mouv.grounded = true;
                    wind = (Random.value * 10) - 5;
                    EXPLOSION.transform.position = proj.projectile.transform.position;
                    EXPLOSION.GetComponent<Animator>().SetTrigger("Explosion");
                }
            }
            if (bulletTime)
            {
                proj.projectile.GetComponent<Rigidbody2D>().AddForce(new Vector2(wind, 0));
            }
        }
        if (gameState==11)
        {
            if (Staticvar.winner)
            {
                Bot.GetComponent<SpriteRenderer>().sprite = ded;
                Bot.GetComponent<Rigidbody2D>().velocity = new Vector3(0, 5, 0);
                proj.projectile.GetComponent<Ball>().Boom.Stop();
                Bong.Play();
                gameState = 12;
            }
            else
            {
                Joueur.GetComponent<SpriteRenderer>().sprite = ded;
                Joueur.GetComponent<Rigidbody2D>().velocity = new Vector3(0, 5, 0);
                proj.projectile.GetComponent<Ball>().Boom.Stop();
                Bong.Play();
                gameState = 12;
            }
            
        }
        if (gameState == 12)
        {
            if (temps > 5)
            {
                SceneManager.LoadScene("End");
            }
            temps += Time.fixedDeltaTime;
        }
    }
}

