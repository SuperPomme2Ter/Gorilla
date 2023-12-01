using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class IAMovement : MonoBehaviour
{
    // Start is called before the first frame update
    public main game;
    public IATurn raycast;
    public terrain _terrain;
    public Rigidbody2D rb;
    public GameObject joueur;
    public int nbDep;
    private bool collision;
    void Start()
    {
        collision = false;
        nbDep = 0;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (game.gameState == 5 || game.gameState == 7 || game.gameState == 9)
        {
            if (nbDep < 30)
            {
                foreach (var Col in _terrain.ground)
                {
                    if (Col.GetComponent<Collider2D>().OverlapPoint(transform.position + new Vector3(raycast.sens.x * 5, -0.8f, 0)))
                    {
                        collision = true;
                        break;
                    }
                    else
                    {
                        collision = false;
                    }
                }
                if (collision)
                {
                    rb.velocity = new Vector2(rb.velocity.x, 10);
                }
                else
                {
                    if (joueur.transform.position.y >= transform.position.y + 2)
                    {
                        if (math.abs(joueur.transform.position.x - transform.position.x) > 2f)
                        {
                            rb.velocity = new Vector2(raycast.sens.x * 5, rb.velocity.y);
                        }
                        else

                        {
                            rb.velocity = new Vector2(-raycast.sens.x * 5, rb.velocity.y);
                        }
                    }
                    else
                    {
                        rb.velocity = new Vector2(raycast.sens.x * 5, rb.velocity.y);
                    }
                }
            }
            else
            {
                if (game.gameState == 5)
                {
                    game.gameState = 6;
                    raycast.Recall();
                    nbDep =0;
                }
                if (game.gameState == 7)
                {
                    game.gameState = 8;
                    raycast.Recall();
                    nbDep = 0;
                }
                if (game.gameState == 9)
                {
                    game.gameState = 1;
                    nbDep = 0;
                }
            }
            nbDep += 1;
        
        }
    }
}
