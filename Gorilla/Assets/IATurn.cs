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
    public trajectory viseur;
    public Vector2 maxPos;
    public Vector2 minPos;

    public int nbTry;
    public int collision;
    public Vector3 sens;
    public float x;
    public float y;
    public Vector3 currentPos;
    public Vector3 v;

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
        if (game.gameState == 4 || game.gameState == 6 || game.gameState==8)
        {
            viseur.trail.enabled = true;
            viseur.trail.startColor = Color.red;
            viseur.trail.endColor = Color.black;
            if (nbTry < 350)
            {
                v = (transform.position + new Vector3(0, 1.5f) + dir) - (transform.position + new Vector3(0, 1.5f));
                currentPos = transform.position + new Vector3(0, 1.5f);
                v = (transform.position + new Vector3(0, 1.5f) + dir) - (transform.position + new Vector3(0, 1.5f));
                currentPos = transform.position + new Vector3(0, 1.5f);
                for (int i = 0; i < 500; i++)
                {

                    foreach (var Col in _terrain.ground)
                    {
                        if (Col.GetComponent<Collider2D>().OverlapPoint(currentPos + new Vector3(sens.x * 0.5f, -0.5f, 0)) || Col.GetComponent<BoxCollider2D>().OverlapPoint(currentPos - new Vector3(sens.x * 0.5f, -0.5f, 0)))
                        {
                            if (Col.CompareTag("Wall"))
                            {
                                
                                if (Col.GetComponent<Collider2D>().OverlapPoint(currentPos + new Vector3(-sens.x * 0.5f, -1, 0)))
                                {
                                    
                                    collision = 2;
                                }
                                else
                                {
                                    collision = 1;
                                    
                                }
                                maxPos.y = maxPos.y + 10f * Time.fixedDeltaTime;
                            }
                            break;
                        }
                        else
                        {
                            collision = 0;
                        }
                    }
                    if (currentPos.y < -5.0f || collision == 1 || collision == 2)
                    {
                        viseur.trail.positionCount = i;
                        break;
                    }

                    v +=(new Vector3(game.wind,0,0)+ Physics.gravity) * Time.fixedDeltaTime;
                    Vector3 nextPos = currentPos + v * Time.fixedDeltaTime;
                    viseur.positions[i] = currentPos;
                    currentPos = nextPos;
                    if (rb.gameObject.GetComponent<CapsuleCollider2D>().OverlapPoint(currentPos))
                    {
                        proj.projectile.GetComponent<Ball>().createBall(transform.position + new Vector3(0, 1.5f), dir.x, dir.y);
                        game.gameState = 3;
                        game.bulletTime = true;
                        viseur.trail.enabled = false;


                    }


                }
                viseur.trail.SetPositions(viseur.positions);
                if (rb.gameObject.GetComponent<CapsuleCollider2D>().OverlapPoint(currentPos))
                {
                    proj.projectile.GetComponent<Ball>().createBall(transform.position + new Vector3(0, 1.5f), dir.x, dir.y);
                    game.gameState = 3;
                    game.bulletTime = true;
                    viseur.trail.enabled = false;


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
                        if (currentPos.x < maxPos.x - 0.4)
                        {
                            dir.x += x * Time.fixedDeltaTime;
                        }
                    }
                    if (currentPos.x > maxPos.x + 0.4)
                    {
                        dir.x -= x * Time.fixedDeltaTime;
                    }
                    
                    if (Vector3.Distance(rb.position, new Vector2(currentPos.x, currentPos.y)) < 3)
                    {
                        x = 5;
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
                if (game.gameState == 4)
                {
                    game.gameState = 5;
                    viseur.trail.enabled = false;
                }
                if (game.gameState == 6)
                {
                    game.gameState = 7;
                    viseur.trail.enabled = false;
                }
                if (game.gameState == 8)
                {
                    game.gameState = 9;
                    viseur.trail.enabled = false;
                }
                
            }
        }
    }
}
