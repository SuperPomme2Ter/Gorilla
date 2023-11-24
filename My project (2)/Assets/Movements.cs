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
    public BoxCollider2D col;
    private bool grounded;
    [SerializeField]
    private InputActionReference Jump, GoLeft, GoRight;
    public Vector2 playerVelocity = new Vector2(0f, 0f);
    [SerializeField] public GameObject inst_projectile;
    GameObject projectile;
    public main game;


    void Start()

    {
        projectile = Instantiate(inst_projectile, new Vector2(-10000, -1000), transform.rotation);
        rb = GetComponent<Rigidbody2D>();
        col = GetComponent<BoxCollider2D>();
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        grounded = true;


    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        grounded = false;
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
            projectile.GetComponent<Ball>().updateBall();
        }
    }
    public void Throw(InputAction.CallbackContext ctx)
    {
        if (game.gameState==1) { 
            if (ctx.phase == InputActionPhase.Started)
            {
                // GameObject monClone = Instantiate(ball, transform.position + new Vector3(1, 0, 0), transform.rotation);

                projectile.GetComponent<Ball>().createBall(transform.position + new Vector3(1, 0), 5, 1);
                print("aaaawababugh");
            }
        }

    }
}
