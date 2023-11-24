using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    // Start is called before the first frame update
    public Rigidbody2D rb;
    Vector2 vel;
    public void createBall(Vector2 pos, float velX, float velY)
    {
        rb.velocity = Vector2.zero;
        vel = new Vector2(velX, velY);
        rb.position = pos;
        rb.velocity += vel;

    }
    public void updateBall()
    {
        if (rb.velocity.x>0 ) { 
            rb.velocity -=new Vector2(0.1f,0);
        }
        else if (rb.velocity.y==0)
        {
            rb.velocity = Vector2.zero;
        }
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {

    }
}
