using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;
using UnityEngine.InputSystem;

public class Movements : MonoBehaviour
{
    // Start is called before the first frame update
    public Rigidbody2D rb;
    public BoxCollider2D sol;
    public bool grounded;
    [SerializeField]
    private InputActionReference Jump, GoLeft, GoRight;
    public Vector2 playerVelocity = new Vector2(0f, 0f);
    
    public main game;


    void Start()

    {
        
        rb = GetComponent<Rigidbody2D>();
        sol = GetComponent<BoxCollider2D>();
    }
    
    private void OnTriggerEnter2D(Collider2D sol)
    {
        grounded = true;


    }
    private void OnTriggerExit2D(Collider2D sol)
    {
        if (!game.bulletTime)
        {
            grounded = false;
        }
    }
    // Update is called once per frame
    void Update()
    {

    }

    void FixedUpdate()
    {   if (game.gameState==1)
        {
            if (grounded)
            {
                if (Jump.action.inProgress)
                {
                    print("aaaawababugh");
                    rb.velocity = new Vector2(rb.velocity.x, 10);
                }
            }
            if (GoLeft.action.inProgress)
            {
                rb.velocity = new Vector2(-5, rb.velocity.y);
            }
            if (GoRight.action.inProgress)
            {
                rb.velocity = new Vector2(5, rb.velocity.y);
            }
            game.transition = false;
            game.bulletTime = false;
            
        }
    }
    public void ShootMode(InputAction.CallbackContext ctx)
    {
        if (!game.transition)
        {
            if (ctx.phase == InputActionPhase.Started)
            {

                if (game.gameState == 1)
                {
                    game.gameState = 2;
                    rb.velocity = new Vector2(0, rb.velocity.y);
                    game.transition = true;
                    print("Wop Wop Wop");
                }
            }
        }

    }

}
