using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class IATurn : MonoBehaviour
{
    // Start is called before the first frame update
    public main game;
    public Vector3 dir;
    public Rigidbody2D rb;
    public ShootTurn proj;
    public terrain _terrain;
    public Vector2 maxPos;
    public Vector2 minPos;

    public int nbTry;
    public int collision;
    private Vector3 sens;
    public float x;
    public float y;

    void Start()
    {
         maxPos =new Vector2(rb.position.x,rb.position.y);
        minPos = new Vector2(rb.position.x * 0.5f, rb.position.y * 0.5f) ;
        dir = new Vector3(0,0,0);
        sens = new Vector3(0, 0, 0);
        collision = 0;
        nbTry = 0;
        x=10;
        y = 10;

    }
    public void Recall()
    {
        dir = new Vector3(0, 0, 0);
        maxPos = new Vector2(rb.position.x, rb.position.y);
        minPos = new Vector2(rb.position.x*0.5f, rb.position.y * 0.05f);
        nbTry = 0;
        x = 10;
        y = 10;
        game.bulletTime = false;
        if (rb.position.x - transform.position.x < 0)
        {
            sens.x = -1;
        }
        else
        {
            sens.x = 1;
        }

    }


    // Update is called once per frame
    void FixedUpdate()
    {
        if (game.gameState == 4)
        {
            if (nbTry < 400)
            {
                Vector3 v = (transform.position + sens + dir) - (transform.position + sens);
                Vector3 currentPos = transform.position + sens;
                v = (transform.position + sens + dir) - (transform.position + sens);
                currentPos = transform.position + sens;
                for (int i = 0; i < 600; i++)
                {

                    foreach (var Col in _terrain.ground)
                    {
                        if (Col.GetComponent<Collider2D>().OverlapPoint(currentPos + new Vector3(sens.x * 0.4f, -0.4f, 0)) || Col.GetComponent<BoxCollider2D>().OverlapPoint(currentPos - new Vector3(sens.x * 0.4f, -0.4f, 0)))
                        {
                            if (Col.CompareTag("Wall"))
                            {
                                if (Col.GetComponent<Collider2D>().OverlapPoint(currentPos + new Vector3(-sens.x * 0.4f, -1, 0)))
                                {
                                    collision = 2;
                                }
                                else
                                {
                                    collision = 1;
                                }
                                maxPos.y = maxPos.y + 10f * Time.fixedDeltaTime;
                            }
                        }
                        else
                        {
                            collision = 0;
                        }
                    }
                    if (currentPos.y < -5.0f || collision == 1 || collision == 2)
                    {
                        break;
                    }

                    v += Physics.gravity * Time.fixedDeltaTime;
                    Vector3 nextPos = currentPos + v * Time.fixedDeltaTime;
                    Debug.DrawLine(currentPos, nextPos, Color.cyan);
                    currentPos = nextPos;
                    if (rb.gameObject.GetComponent<CapsuleCollider2D>().OverlapPoint(currentPos))
                    {
                        proj.projectile.GetComponent<Ball>().createBall(transform.position + sens, dir.x, dir.y);
                        game.gameState = 3;
                        game.bulletTime = true;


                    }


                }
                if (rb.gameObject.GetComponent<CapsuleCollider2D>().OverlapPoint(currentPos))
                {
                    proj.projectile.GetComponent<Ball>().createBall(transform.position + sens, dir.x, dir.y);
                    game.gameState = 3;
                    game.bulletTime = true;


                }
                else
                {
                    if (collision == 1)
                    {
                        if (currentPos.y > maxPos.y)
                        {
                            dir.y -= y * Time.fixedDeltaTime;
                        }
                        if (currentPos.y < maxPos.y - 0.5f)
                        {
                            dir.y += y * Time.fixedDeltaTime;
                        }
                    }

                    if (collision == 0 || collision == 2)
                    {
                        if (currentPos.x < maxPos.x - 0.5)
                        {
                            dir.x += x * Time.fixedDeltaTime;
                        }
                        if (currentPos.x > maxPos.x + 0.5)
                        {
                            dir.x -= x * Time.fixedDeltaTime;
                        }
                    }
                    if (Vector3.Distance(rb.position, new Vector2(currentPos.x, currentPos.y)) < 3)
                    {
                        x = 2;
                    }
                    else
                    {
                        x = 10;
                    }
                    nbTry += 1;
                    /* if (currentPos.y < minPos.y)
                     {
                         dir.y += 30f * Time.fixedDeltaTime;
                     }*/
                }
            }
            else
            {
                game.gameState = 5;
            }
        }
    }
}
