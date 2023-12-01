using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    // Start is called before the first frame update
    
    public Rigidbody2D rb;
    public CircleCollider2D col;
    public AudioSource Boom;
    public bool transition=false;
    public int touch;


    
    public main game;
    
    Vector2 vel;
    public void createBall(Vector2 pos, float velX, float velY)
    {
        rb.velocity = Vector2.zero;
        vel = new Vector2(velX, velY);
        rb.position = pos;
        rb.velocity += vel;


    }
    public void OnTriggerEnter2D(Collider2D col)
    {
        Boom.enabled = true;
        rb.velocity = Vector2.zero;
        rb.position = new Vector2(1000, -1000);
        Boom.Play();
        transition = true;
        if (col.gameObject.name == "Joueur")
        {
            touch = 1;
        }
        if (col.gameObject.name == "Bot")
        {
            touch = 2;
        }
        if (col.gameObject.tag == "Wall")
        {
            touch = 2;
        }
    }
 
    void Start()
    {
        Boom.enabled = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!Boom.isPlaying)
        {
            Boom.enabled = false;
        }
    }
}
